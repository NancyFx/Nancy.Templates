namespace Nancy.Templates.Builder.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using Model;

    /// <summary>
    /// Containing extensions for <see cref="Template"/> xml import implementations.
    /// </summary>
    public static class TemplateImportXmlExtensions
    {
        /// <summary>
        /// Parses available files in MSBuild project file
        /// </summary>
        /// <param name="template">source template</param>
        /// <returns>Found files in project file</returns>
        /// <exception cref="DirectoryNotFoundException">if project folder not found</exception>
        public static TemplateFile[] ParseProjectFiles(this Template template)
        {
            var rootPath =
                Path.GetDirectoryName(template.ProjectFileName);

            if (string.IsNullOrEmpty(rootPath) || !Directory.Exists(rootPath))
            {
                throw new DirectoryNotFoundException();
            }

            var xDoc =
                XDocument.Load(template.ProjectFileName);

            return (
                from project in xDoc.Elements(ProjectXElement.Project)
                from itemGroup in project.Elements(ProjectXElement.ItemGroup)
                from element in itemGroup.Elements()
                where element.Name != ProjectXElement.Reference && element.Name!=ProjectXElement.Import
                from include in element.Attributes("Include")
                let value = include.Value
                where !string.IsNullOrEmpty(value)
                select new TemplateFile
                {
                    Name = Path.GetFileName(value),
                    FilePath = Path.Combine(rootPath, value),
                    ZipPath = value,
                    ReplaceParameters = CheckIfReplaceFile(value)
                })
                .Union(
                    new[]
                    {
                        new TemplateFile
                        {
                            Name = Path.GetFileName(template.ProjectFileName),
                            FilePath = template.ProjectFileName,
                            ZipPath = Path.GetFileName(template.ProjectFileName),
                            Exclude = true,
                            ReplaceParameters = true
                        },
                        StaticConfig.IconTemplateFile,
                        StaticConfig.PreviewTemplateFile
                    })
                .ToArray();
        }

        /// <summary>
        /// Parses project folder / file structure
        /// </summary>
        /// <param name="template">source template</param>
        /// <returns>Template folder structure</returns>
        /// <exception cref="DirectoryNotFoundException">if project folder not found</exception>
        public static TemplateFolder ParseProjectFolders(this Template template)
        {
            var rootPath =
                Path.GetDirectoryName(template.ProjectFileName);

            if (string.IsNullOrEmpty(rootPath) || !Directory.Exists(rootPath))
            {
                throw new DirectoryNotFoundException();
            }

            var fileLookup =
                template.Files
                .Where(file => !file.Exclude)
                .ToLookup(key => Path.GetDirectoryName(key.ZipPath), value => value);

            var projectDir =
                new DirectoryInfo(rootPath);

            Func<IEnumerable<DirectoryInfo>, string, TemplateFolder[]> toTemplateFolder =
                null;

            toTemplateFolder =
                (directories, zipPath) => (
                    from dir in directories
                    let curZipPath =
                        (dir == projectDir)
                            ? string.Empty
                            : string.Concat(zipPath, "\\", dir.Name)
                    let files = fileLookup[curZipPath].ToArray()
                    where files.Length > 0
                    select new TemplateFolder
                            {
                                Name = dir.Name,
                                Folders = toTemplateFolder(dir.EnumerateDirectories(), curZipPath),
                                Files = files
                            })
                    .ToArray();

            return toTemplateFolder(
                new[] { projectDir },
                string.Empty)
                .FirstOrDefault();
        }

        /// <summary>
        /// Check if template variables should be replace on given file
        /// </summary>
        /// <param name="filePath">path to source file</param>
        /// <returns>boolean</returns>
        private static bool CheckIfReplaceFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                return false;
            }

            var extension =
                Path.GetExtension(filePath)
                .ToLower();

            switch (extension)
            {
                case ".resx":
                case ".png":
                case ".jpg":
                case ".dll":
                case "":
                    return false;

                default:
                    return true;
            }
        }
    }
}