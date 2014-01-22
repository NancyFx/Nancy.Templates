namespace Nancy.Templates.Builder
{
    using Model;

    /// <summary>
    /// Temporary static config until config loaded from file
    /// </summary>
    /// <remarks>
    /// TODO: Load config from file, remove CSharp assumtions
    /// </remarks>
    public static class StaticConfig
    {
        private const string RootPath = @"..\..\..\Nancy.Templates\";
        private const string PreviewImagePath = RootPath + "nancy-logo-preview.jpg";
        private const string IconImagePath = RootPath + "nancy-logo-icon.jpg";
        
        /// <summary>
        /// Target path for templates
        /// </summary>
        public const string PackagePath = RootPath + @"Nancy.Templates\ProjectTemplates\CSharp\Web\";

        /// <summary>
        /// Icon image file used in templates
        /// </summary>
        public static readonly TemplateFile IconTemplateFile =
            new TemplateFile
            {
                FilePath = IconImagePath,
                ZipPath = "__TemplateIcon.jpg",
                Exclude = true
            };

        /// <summary>
        /// Preview image files used in template
        /// </summary>
        public static readonly TemplateFile PreviewTemplateFile =
            new TemplateFile
            {
                FilePath = PreviewImagePath,
                ZipPath = "__PreviewImage.jpg",
                Exclude = true
            };

        /// <summary>
        /// Templates to process
        /// </summary>
        public static readonly TemplateConfig[] TemplateConfigProjects =
        {
            new TemplateConfig
            {
                ProjectFileName = RootPath + @"Nancy.Templates.CSharp.AspNetHost\Nancy.Templates.CSharp.AspNetHost.csproj",
                Name = "Nancy Application with ASP.NET hosting",
                DefaultName = "NancyApplication",
                Description = "A project for creating a Nancy application that is hosted on ASP.NET",
                ProjectType = "CSharp"
            },
            new TemplateConfig
            {
                ProjectFileName = RootPath + @"Nancy.Templates.CSharp.AspNetHostWithRazor\Nancy.Templates.CSharp.AspNetHostWithRazor.csproj",
                Name = "Nancy Application with ASP.NET hosting and Razor",
                DefaultName = "NancyApplication",
                Description = "A project for creating a Nancy application with Razor support that is hosted on ASP.NET",
                ProjectType = "CSharp"
            },
            new TemplateConfig
            {
                ProjectFileName = RootPath + @"Nancy.Templates.CSharp.SelfHost\Nancy.Templates.CSharp.SelfHost.csproj",
                Name = "Nancy Application with self-hosting",
                DefaultName = "NancyApplication",
                Description = "A project for creating a Nancy application that is self-hosted",
                ProjectType = "CSharp"
            },
            new TemplateConfig
            {
                ProjectFileName = RootPath + @"Nancy.Templates.CSharp.SelfHostWithRazor\Nancy.Templates.CSharp.SelfHostWithRazor.csproj",
                Name = "Nancy Application with self-hosting and Razor",
                DefaultName = "NancyApplication",
                Description = "A project for creating a Nancy application with Razor support that is self-hosted",
                ProjectType = "CSharp"
            },
            new TemplateConfig
            {
                ProjectFileName = RootPath + @"Nancy.Templates.CSharp.Demo\Nancy.Templates.CSharp.Demo.csproj",
                Name = "Nancy Demo Application Template",
                DefaultName = "Nancy.DemoApplication",
                Description = "A project for creating a Nancy based demo application",
                ProjectType = "CSharp"
            },
            new TemplateConfig
            {
                ProjectFileName = RootPath + @"Nancy.Templates.CSharp.EmptyAspNetHost\Nancy.Templates.CSharp.EmptyAspNetHost.csproj",
                Name = "Nancy Empty Application with ASP.NET hosting",
                DefaultName = "NancyApplication",
                Description = "An empty project for creating a Nancy application that is hosted on ASP.NET",
                ProjectType = "CSharp"
            },
            new TemplateConfig
            {
                ProjectFileName =RootPath + @"Nancy.Templates.CSharp.EmptyAspNetHostingWithRazor\Nancy.Templates.CSharp.EmptyAspNetHostWithRazor.csproj",
                Name = "Nancy Empty Application with ASP.NET hosting and Razor",
                DefaultName = "NancyApplication",
                Description = "An empty project for creating a Nancy application with Razor support that is hosted on ASP.NET",
                ProjectType = "CSharp"
            },
            new TemplateConfig
            {
                ProjectFileName = RootPath + @"Nancy.Templates.CSharp.EmptySelfHost\Nancy.Templates.CSharp.EmptySelfHost.csproj",
                Name = "Nancy Empty Application with self-hosting",
                DefaultName = "NancyApplication",
                Description = "An empty project for creating a Nancy application that is self-hosted",
                ProjectType = "CSharp"
            },
            new TemplateConfig
            {
                ProjectFileName = RootPath + @"Nancy.Templates.CSharp.EmptySelfHostWithRazor\Nancy.Templates.CSharp.EmptySelfHostWithRazor.csproj",
                Name = "Nancy Empty Application with self-hosting and Razor",
                DefaultName = "NancyApplication",
                Description = "An empty project for creating a Nancy application with Razor support that is self-hosted",
                ProjectType = "CSharp"
            }
        };
    }
}