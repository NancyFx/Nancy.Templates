namespace Nancy.Templates.Builder.Model
{
    /// <summary>
    /// Target templae blueprint
    /// </summary>
    public class Template
    {
        /// <summary>
        /// Project file name with path
        /// </summary>
        public string ProjectFileName { get; set; }

        /// <summary>
        /// Project file name without path
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// Template name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Template default name
        /// </summary>
        public object DefaultName { get; set; }

        /// <summary>
        /// Template description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Template zip archive desitination
        /// </summary>
        public string TargetPath { get; set; }

        /// <summary>
        /// Type of MSBuild project i.e. CSharp
        /// </summary>
        public string ProjectType { get; set; }

        /// <summary>
        /// All files to be added to zip Archive
        /// </summary>
        public TemplateFile[] Files { get; set; }

        /// <summary>
        /// All files to be added to template manifest
        /// </summary>
        public TemplateFolder ProjectFolder { get; set; }

        /// <summary>
        /// Project default name space
        /// </summary>
        public string ProjectDefaultNamespace { get; set; }

        /// <summary>
        /// Template Nuget packages
        /// </summary>
        public TemplatePackage[] Packages { get; set; }
    }
}