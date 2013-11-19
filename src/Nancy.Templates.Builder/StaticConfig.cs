namespace Nancy.Templates.Builder
{
    using System;
    using Model;
    struct StaticConfig
    {
        private const           string          RootPath = @"..\..\..\Nancy.Templates\";
        private const           string          PreviewImagePath = RootPath + "nancy-logo-preview.jpg";
        private const           string          IconImagePath = RootPath + "nancy-logo-icon.jpg";
        public  const           string          PackagePath = RootPath + @"Nancy.Templates\ProjectTemplates\CSharp\Web\";

        public static readonly  TemplateFile    IconTemplateFile =
            new TemplateFile
            {
                FilePath    =   IconImagePath       ,
                ZipPath     =   "__TemplateIcon.jpg",
                Exclude     =   true
            };

        public static readonly TemplateFile PreviewTemplateFile =
            new TemplateFile
            {
                FilePath    =   PreviewImagePath    ,
                ZipPath     =   "__PreviewImage.jpg",
                Exclude     =   true
            };

        //TODO: Load config from file
        public static readonly TemplateConfig[] TemplateConfigProjects =
        {
            new TemplateConfig
            {
                ProjectFileName = RootPath + @"Nancy.Templates.CSharp.AspNetHost\Nancy.Templates.CSharp.AspNetHost.csproj"  ,
                Name            = "Nancy Application with ASP.NET hosting"                                                  ,
                Description     = "A project for creating a Nancy application that is hosted on ASP.NET"                    ,
                ProjectType     = "CSharp"
            },
            new TemplateConfig
            {
                ProjectFileName = RootPath + @"Nancy.Templates.CSharp.AspNetHostWithRazor\Nancy.Templates.CSharp.AspNetHostWithRazor.csproj"    ,
                Name            = "Nancy Application with ASP.NET hosting and Razor"                                                            ,
                Description     = "A project for creating a Nancy application with Razor support that is hosted on ASP.NET"                     ,
                ProjectType     = "CSharp"
            },
            new TemplateConfig
            {
                ProjectFileName = RootPath + @"Nancy.Templates.CSharp.SelfHost\Nancy.Templates.CSharp.SelfHost.csproj"  ,
                Name            = "Nancy Application with self-hosting"                                                 ,
                Description     = "A project for creating a Nancy application that is self-hosted"                      ,
                ProjectType     = "CSharp"
            },
            new TemplateConfig
            {
                ProjectFileName = RootPath + @"Nancy.Templates.CSharp.SelfHostWithRazor\Nancy.Templates.CSharp.SelfHostWithRazor.csproj"    ,
                Name            = "Nancy Application with self-hosting and Razor"                                                           ,
                Description     = "A project for creating a Nancy application with Razor support that is self-hosted"                       ,
                ProjectType     = "CSharp"
            },
            new TemplateConfig
            {
                ProjectFileName = RootPath + @"Nancy.Templates.CSharp.Demo\Nancy.Templates.CSharp.Demo.csproj"  ,
                Name            = "Nancy Demo Application Template"                                             ,
                Description     = "A project for creating a Nancy based demo application"                       ,
                ProjectType     = "CSharp"
            },
            new TemplateConfig
            {
                ProjectFileName = RootPath + @"Nancy.Templates.CSharp.EmptyAspNetHost\Nancy.Templates.CSharp.EmptyAspNetHost.csproj"    ,
                Name            = "Nancy Empty Application with ASP.NET hosting"                                                        ,
                Description     = "An empty project for creating a Nancy application that is hosted on ASP.NET"                         ,
                ProjectType     = "CSharp"
            },
            new TemplateConfig
            {
                ProjectFileName = RootPath + @"Nancy.Templates.CSharp.EmptyAspNetHostingWithRazor\Nancy.Templates.CSharp.EmptyAspNetHostWithRazor.csproj"   ,
                Name            = "Nancy Empty Application with ASP.NET hosting and Razor"                                                                  ,
                Description     = "An empty project for creating a Nancy application with Razor support that is hosted on ASP.NET"                          ,
                ProjectType     = "CSharp"
            },
            new TemplateConfig
            {
                ProjectFileName = RootPath + @"Nancy.Templates.CSharp.EmptySelfHost\Nancy.Templates.CSharp.EmptySelfHost.csproj"    ,
                Name            = "Nancy Empty Application with self-hosting"                                                       ,
                Description     = "An empty project for creating a Nancy application that is self-hosted"                           ,
                ProjectType     = "CSharp"
            },
            new TemplateConfig
            {
                ProjectFileName = RootPath + @"Nancy.Templates.CSharp.EmptySelfHostWithRazor\Nancy.Templates.CSharp.EmptySelfHostWithRazor.csproj"  ,
                Name            = "Nancy Empty Application with self-hosting and Razor"                                                             ,
                Description     = "An empty project for creating a Nancy application with Razor support that is self-hosted"                        ,
                ProjectType     = "CSharp"
            }
        };
    }
}