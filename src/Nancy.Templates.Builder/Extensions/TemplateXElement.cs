namespace Nancy.Templates.Builder.Extensions
{
    /// <summary>
    /// VSTemplate Xml Element XNames constants
    /// </summary>
    /// <remarks>
    /// TODO: Doument element types
    /// </remarks>
    internal static class TemplateXElement
    {
        private const string TemplateXmlNamespace = "http://schemas.microsoft.com/developer/vstemplate/2005";
        public const string Root = "<VSTemplate Version=\"3.0.0\" xmlns=\"" + TemplateXmlNamespace + "\" Type=\"Project\" />";
        public const string TemplateData = "{" + TemplateXmlNamespace + "}TemplateData";
        public const string TemplateContent = "{" + TemplateXmlNamespace + "}TemplateContent";
        public const string Name = "{" + TemplateXmlNamespace + "}Name";
        public const string Description = "{" + TemplateXmlNamespace + "}Description";
        public const string ProjectType = "{" + TemplateXmlNamespace + "}ProjectType";
        public const string ProjectSubType = "{" + TemplateXmlNamespace + "}ProjectSubType";
        public const string SortOrder = "{" + TemplateXmlNamespace + "}SortOrder";
        public const string CreateNewFolder = "{" + TemplateXmlNamespace + "}CreateNewFolder";
        public const string DefaultName = "{" + TemplateXmlNamespace + "}DefaultName";
        public const string ProvideDefaultName = "{" + TemplateXmlNamespace + "}ProvideDefaultName";
        public const string LocationField = "{" + TemplateXmlNamespace + "}LocationField";
        public const string EnableLocationBrowseButton = "{" + TemplateXmlNamespace + "}EnableLocationBrowseButton";
        public const string Icon = "{" + TemplateXmlNamespace + "}Icon";
        public const string PreviewImage = "{" + TemplateXmlNamespace + "}PreviewImage";
        public const string Project = "{" + TemplateXmlNamespace + "}Project";
        public const string ProjectItem = "{" + TemplateXmlNamespace + "}ProjectItem";
        public const string Folder = "{" + TemplateXmlNamespace + "}Folder";
        public const string WizardExtension = "{" + TemplateXmlNamespace + "}WizardExtension";
        public const string Assembly = "{" + TemplateXmlNamespace + "}Assembly";
        public const string FullClassName = "{" + TemplateXmlNamespace + "}FullClassName";
        public const string WizardData = "{" + TemplateXmlNamespace + "}WizardData";
        public const string Packages = "{" + TemplateXmlNamespace + "}packages";
        public const string Package = "{" + TemplateXmlNamespace + "}package";
        
    }
}