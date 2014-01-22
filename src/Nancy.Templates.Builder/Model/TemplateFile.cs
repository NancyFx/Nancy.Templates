namespace Nancy.Templates.Builder.Model
{
    /// <summary>
    /// Template file entry
    /// </summary>
    public class TemplateFile
    {
        /// <summary>
        /// File name without path
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// File name with path
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Relative file path used for zip entry
        /// </summary>
        public string ZipPath { get; set; }

        /// <summary>
        /// If file should be included in 
        /// </summary>
        public bool Exclude { get; set; }

        /// <summary>
        /// If template varianble replacements should be applied to file
        /// </summary>
        public bool ReplaceParameters { get; set; }

        /// <summary>
        /// If file should be compiled
        /// </summary>
        public bool Compile { get; set; }
    }
}