namespace Nancy.Templates.Builder.Extensions
{
    /// <summary>
    /// MSBuild Project Xml Element XNames
    /// </summary>
    public static class ProjectXElement
    {
        private const string XmlNamespace = "http://schemas.microsoft.com/developer/msbuild/2003";
        
        /// <summary>
        /// Project root element
        /// </summary>
        public const string Project = "{" + XmlNamespace + "}Project";
        
        /// <summary>
        /// Item group element
        /// </summary>
        public const string ItemGroup = "{" + XmlNamespace + "}ItemGroup";
        
        /// <summary>
        /// Assembly reference element
        /// </summary>
        public const string Reference = "{" + XmlNamespace + "}Reference";

        /// <summary>
        /// Namespace import element
        /// </summary>
        public const string Import  = "{" + XmlNamespace + "}Import";
    }
}