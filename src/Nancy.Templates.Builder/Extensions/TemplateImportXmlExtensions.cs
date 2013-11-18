namespace Nancy.Templates.Builder.Extensions
{
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using Model;
    public static class TemplateImportXmlExtensions
    {
        private static readonly TemplateFile[] EmptyFile = new TemplateFile[0];
        public static TemplateFile[] ParseProjectFiles(this Template template)
        {
            var rootPath = Path.GetDirectoryName(template.ProjectFileName);
            if (
                string.IsNullOrEmpty(rootPath) ||
                !Directory.Exists(rootPath)
                )
                return EmptyFile;

            var xDoc = XDocument.Load(template.ProjectFileName);
            return (
                from    project         in xDoc.Elements(ProjectXElement.Project)
                from    itemGroup       in project.Elements(ProjectXElement.ItemGroup)
                from    element         in itemGroup.Elements()
                where   element.Name != ProjectXElement.Reference
                from    include         in element.Attributes("Include")
                let     value = include.Value
                where   !string.IsNullOrEmpty(value)
                select new TemplateFile 
                    {
                        Name                =   Path.GetFileName(value)         ,
                        FilePath            =   Path.Combine(
                                                    rootPath,
                                                    value
                                                )                               ,
                        ZipPath             =   value                           ,
                        ReplaceParameters   =   CheckIfReplaceFile(value)
                    }
                ).Union(
                    new[]
                    {
                        new TemplateFile    
                            {
                                Name                = Path.GetFileName(template.ProjectFileName)    ,
                                FilePath            = template.ProjectFileName                      ,
                                ZipPath             = Path.GetFileName(template.ProjectFileName)    ,
                                Exclude             = true                                          ,
                                ReplaceParameters   = true
                            }                           ,
                        StaticConfig.IconTemplateFile   ,
                        StaticConfig.PreviewTemplateFile
                    }
                )
                .ToArray();
        }

        private static bool CheckIfReplaceFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                return false;

            var extension = Path.GetExtension(filePath).ToLower();
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
