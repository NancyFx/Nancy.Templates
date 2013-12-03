namespace Nancy.Templates.Builder.Extensions
{
    using System.IO;
    using Model;

    /// <summary>
    /// Containing extensions for <see cref="TemplateConfig"/> implementations.
    /// </summary>
    public static class TemplateConfigExtensions
    {
        /// <summary>
        /// Parses MSBuild Project from Config
        /// </summary>
        /// <param name="config">source template config</param>
        /// <returns>Parsed template</returns>
        public static Template ParseProjectFileFromConfig(this TemplateConfig config)
        {
            var template =
                new Template
                {
                    Name = config.Name,
                    Description = config.Description,
                    ProjectFileName = config.ProjectFileName,
                    ProjectType = config.ProjectType,
                    ProjectName = Path.GetFileName(config.ProjectFileName),
                    TargetPath = Path.Combine(StaticConfig.PackagePath, string.Concat(config.Name, ".zip"))
                };
            template.Files = template.ParseProjectFiles();
            template.ProjectFolder = template.ParseProjectFolders();
            return template;
        }
    }
}