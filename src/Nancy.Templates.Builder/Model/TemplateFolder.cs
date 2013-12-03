namespace Nancy.Templates.Builder.Model
{
    /// <summary>
    /// Template folder
    /// </summary>
    public class TemplateFolder
    {
        /// <summary>
        /// Folder name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Folder sub folders
        /// </summary>
        public TemplateFolder[] Folders { get; set; }

        /// <summary>
        /// Folder files
        /// </summary>
        public TemplateFile[] Files { get; set; }
    }
}