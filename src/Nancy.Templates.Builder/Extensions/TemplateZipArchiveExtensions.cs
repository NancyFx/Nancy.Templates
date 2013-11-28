namespace Nancy.Templates.Builder.Extensions
{
    using System;
    using System.IO;
    using System.IO.Compression;
    using Model;

    /// <summary>
    /// Containing extensions for <see cref="Template"/> zip archive implementations.
    /// </summary>
    public static class TemplateZipArchiveExtensions
    {
        /// <summary>
        /// Creates template zip archive, adds file and manifest
        /// </summary>
        /// <param name="template">source template</param>
        public static void CreateTemplateZip(this Template template)
        {
            using (var fileStream = File.Create(template.TargetPath))
            {
                using (var archive = new ZipArchive(fileStream, ZipArchiveMode.Create))
                {
                    Array.ForEach(
                        template.Files,
                        archive.AddFileEntry);

                    template.AddVsMyTemplate(archive);
                }
            }
        }

        /// <summary>
        /// Helper method to add template entry to zip archive
        /// </summary>
        /// <param name="archive"></param>
        /// <param name="file"></param>
        private static void AddFileEntry(
            this ZipArchive archive,
            TemplateFile file
            )
        {
            var fileExists =
                File.Exists(file.FilePath);

            var directoryExists =
                !fileExists && Directory.Exists(file.FilePath);

            if (!fileExists && !directoryExists)
            {
               throw new FileNotFoundException("Source file not found", file.FilePath);
            }

            var entry =
                archive.CreateEntry(file.ZipPath, CompressionLevel.Optimal);

            if (!fileExists)
                return;

            using (Stream
                source = File.OpenRead(file.FilePath),
                target = entry.Open())
            {
                source.CopyTo(target);
            }
        }
    }
}