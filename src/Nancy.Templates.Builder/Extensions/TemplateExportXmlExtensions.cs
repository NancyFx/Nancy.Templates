namespace Nancy.Templates.Builder.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.IO.Compression;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using Model;

    /// <summary>
    /// Containing extensions for <see cref="Template"/> xml export implementations.
    /// </summary>
    public static class TemplateExportXmlExtensions
    {
        /// <summary>
        /// Template manifest target file name
        /// </summary>
        private const string VsTemplate = "MyTemplate.vstemplate";

        /// <summary>
        /// Template Xml format settings, skip declaration and bom
        /// </summary>
        private static readonly XmlWriterSettings VsTemplateXmlWriterSettings = new XmlWriterSettings
        {
            OmitXmlDeclaration = true,
            Indent = true,
            Encoding = new UTF8Encoding(false)
        };

        /// <summary>
        /// Adds template manifest to zip archive
        /// </summary>
        /// <param name="template">source template</param>
        /// <param name="archive">target zip file</param>
        public static void AddVsMyTemplate(this Template template, ZipArchive archive)
        {
            var xVsTemplate =
                template.ToVsTemplate();

            var entry =
                archive.CreateEntry(VsTemplate, CompressionLevel.Optimal);

            using (var target = entry.Open())
            {
                using (var xw = XmlWriter.Create(target, VsTemplateXmlWriterSettings))
                {
                    xVsTemplate.Save(xw);
                }
            }
        }

        /// <summary>
        /// Creates template manifest xml from given template
        /// </summary>
        /// <param name="template">source template</param>
        /// <returns>template manifest xml</returns>
        private static XElement ToVsTemplate(this Template template)
        {
            Func<IList<TemplateFile>, IList<XElement>> filesToXml =
                files => files.OrderBy(file => file.Name)
                    .Select(file => new XElement(
                        TemplateXElement.ProjectItem,
                        new XAttribute(TemplateXAttribute.ReplaceParameters, file.ReplaceParameters),
                        new XAttribute(TemplateXAttribute.TargetFileName, file.Name),
                        file.Name
                        )).ToArray();

            Func<TemplateFolder, IList<XElement>> folderToXml = null;
            folderToXml = folder => folder
                .Folders
                .Select(
                    subfolder => new XElement(
                        TemplateXElement.Folder,
                        new XAttribute(TemplateXAttribute.Name, subfolder.Name),
                        new XAttribute(TemplateXAttribute.TargetFolderName, subfolder.Name),
                        folderToXml(subfolder)
                        ))
                .Union(
                    filesToXml(folder.Files))
                .ToArray();


            var xVsTemplate =
                XElement.Parse(TemplateXElement.Root);

            xVsTemplate.Add(
                new XElement(
                    TemplateXElement.TemplateData,
                    new XElement(TemplateXElement.Name, template.Name),
                    new XElement(TemplateXElement.Description, template.Description),
                    new XElement(TemplateXElement.ProjectType, template.ProjectType),
                    new XElement(TemplateXElement.ProjectSubType, "\r\n    "),
                    new XElement(TemplateXElement.SortOrder, 1000),
                    new XElement(TemplateXElement.CreateNewFolder, true),
                    new XElement(TemplateXElement.DefaultName, template.Name),
                    new XElement(TemplateXElement.ProvideDefaultName, true),
                    new XElement(TemplateXElement.LocationField, "Enabled"),
                    new XElement(TemplateXElement.EnableLocationBrowseButton, true),
                    new XElement(TemplateXElement.Icon, StaticConfig.IconTemplateFile.ZipPath),
                    new XElement(TemplateXElement.PreviewImage, StaticConfig.PreviewTemplateFile.ZipPath)
                    ),
                new XElement(
                    TemplateXElement.TemplateContent,
                    new XElement(
                        TemplateXElement.Project,
                        new XAttribute(TemplateXAttribute.TargetFileName, template.ProjectName),
                        new XAttribute(TemplateXAttribute.File, template.ProjectName),
                        new XAttribute(TemplateXAttribute.ReplaceParameters, true),
                        folderToXml(template.ProjectFolder)
                        )
                    ));

            return xVsTemplate;
        }
    }
}