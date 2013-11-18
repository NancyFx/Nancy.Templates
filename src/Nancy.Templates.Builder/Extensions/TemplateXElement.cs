namespace Nancy.Templates.Builder.Extensions
{
    struct TemplateXElement
    {
        private     const   string  TemplateXmlNamespace        = "http://schemas.microsoft.com/developer/vstemplate/2005"                                      ;
        internal    const   string  Root                        = "<VSTemplate Version=\"3.0.0\" xmlns=\"" + TemplateXmlNamespace + "\" Type=\"Project\" />"    ;
        internal    const   string  TemplateData                = "{" + TemplateXmlNamespace + "}TemplateData"                                                  ;
        internal    const   string  TemplateContent             = "{" + TemplateXmlNamespace + "}TemplateContent"                                               ;
        internal    const   string  Name                        = "{" + TemplateXmlNamespace + "}Name"                                                          ;
        internal    const   string  Description                 = "{" + TemplateXmlNamespace + "}Description"                                                   ;
        internal    const   string  ProjectType                 = "{" + TemplateXmlNamespace + "}ProjectType"                                                   ;
        internal    const   string  ProjectSubType              = "{" + TemplateXmlNamespace + "}ProjectSubType"                                                ;
        internal    const   string  SortOrder                   = "{" + TemplateXmlNamespace + "}SortOrder"                                                     ;
        internal    const   string  CreateNewFolder             = "{" + TemplateXmlNamespace + "}CreateNewFolder"                                               ;
        internal    const   string  DefaultName                 = "{" + TemplateXmlNamespace + "}DefaultName"                                                   ;
        internal    const   string  ProvideDefaultName          = "{" + TemplateXmlNamespace + "}ProvideDefaultName"                                            ;
        internal    const   string  LocationField               = "{" + TemplateXmlNamespace + "}LocationField"                                                 ;
        internal    const   string  EnableLocationBrowseButton  = "{" + TemplateXmlNamespace + "}EnableLocationBrowseButton"                                    ;
        internal    const   string  Icon                        = "{" + TemplateXmlNamespace + "}Icon"                                                          ;
        internal    const   string  PreviewImage                = "{" + TemplateXmlNamespace + "}PreviewImage"                                                  ;
        internal    const   string  Project                     = "{" + TemplateXmlNamespace + "}Project"                                                       ;
        internal    const   string  ProjectItem                 = "{" + TemplateXmlNamespace + "}ProjectItem"                                                   ;
        internal    const   string  Folder                      = "{" + TemplateXmlNamespace + "}Folder"                                                        ;
    }
}