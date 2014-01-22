namespace Nancy.Templates.Builder.Model
{
    /// <summary>
    /// Configuration that describes the template project
    /// </summary>
    public class TemplateConfig
    {
        /// <summary>
        /// Name of template project also used for zip naming
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Name of template project also used for zip naming
        /// </summary>
        public string DefaultName { get; set; }

        /// <summary>
        /// Longer description of template project
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Path to source project
        /// </summary>
        public string ProjectFileName { get; set; }

        /// <summary>
        /// Type of project i.e. CSharp
        /// </summary>
        public string ProjectType { get; set; }
    }
}