namespace Nancy.Templates.Builder.Extensions
{
    using Model;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public static class TemplateConfigExtensions
    {
        
        public static Template ParseProjectFileFromConfig(this TemplateConfig config)
        {
            var template = new Template
            {
                Name            = config.Name               ,
                Description     = config.Description        ,
                ProjectFileName = config.ProjectFileName    ,
                ProjectType     = config.ProjectType
            };
            template.ProjectName    =   Path.GetFileName(template.ProjectFileName);
            template.Files          =   template.ParseProjectFiles();
            template.ProjectFolder  =   template.ParseProjectFolders();
            template.TargetPath     =   Path.Combine(
                                            StaticConfig.PackagePath,
                                            string.Concat(
                                                template.Name,
                                                ".zip"
                                            )
                                        );
            return template;
        }

        private static TemplateFolder ParseProjectFolders(
            this Template template
            )
        {
            var rootPath = Path.GetDirectoryName(template.ProjectFileName);
            if (
                string.IsNullOrEmpty(rootPath) ||
                !Directory.Exists(rootPath)
                )
                return null;

            var fileLookup = template.Files
                .Where(file=>!file.Exclude)
                .ToLookup(
                key => Path.GetDirectoryName(key.ZipPath),
                value => value
                );

            var projectDir = new DirectoryInfo(rootPath);
            Func<IEnumerable<DirectoryInfo>, string, TemplateFolder[]> toTemplateFolder = null;
            toTemplateFolder =
                (directories, zipPath) => (
                    from dir in directories
                    let curZipPath =
                        (dir == projectDir)
                            ? string.Empty
                            : string.Concat(
                                zipPath,
                                "\\",
                                dir.Name
                                ).TrimStart('\\')
                    let files = fileLookup[curZipPath].ToArray()
                    where files.Length > 0
                    select new TemplateFolder
                    {
                        Name = dir.Name,
                        Folders = toTemplateFolder(dir.EnumerateDirectories(), curZipPath),
                        Files = files
                    }
                    ).ToArray();
            return toTemplateFolder(
                new[]
                {
                    projectDir
                },
                string.Empty
                ).FirstOrDefault();
        }
    }
}
