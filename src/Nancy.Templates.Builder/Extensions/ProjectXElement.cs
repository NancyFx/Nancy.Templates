namespace Nancy.Templates.Builder.Extensions
{
    struct ProjectXElement
    {
        private     const string XmlNamespace   = "http://schemas.microsoft.com/developer/msbuild/2003" ;
        internal    const string Project        = "{"   +   XmlNamespace    +   "}Project"              ;
        internal    const string ItemGroup      = "{"   +   XmlNamespace    +   "}ItemGroup"            ;
        internal    const string Reference      = "{"   +   XmlNamespace    +   "}Reference"            ;
    }
}
