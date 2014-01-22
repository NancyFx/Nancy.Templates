using System.Linq;
using System.Text;

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
                        file=>archive.AddFileEntry(file, template.ProjectDefaultNamespace));

                    template.AddVsMyTemplate(archive);
                }
            }
        }

        /// <summary>
        /// Helper method to add template entry to zip archive
        /// </summary>
        /// <param name="archive">target archive</param>
        /// <param name="file">source file</param>
        /// <param name="defaultNamespace">project default namespace</param>
        private static void AddFileEntry(
            this ZipArchive archive,
            TemplateFile file,
            string defaultNamespace
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
                source = (file.Compile) ? PreProcessFile(file.FilePath, defaultNamespace) : File.OpenRead(file.FilePath),
                target = entry.Open())
            {
                source.CopyTo(target);
            }
        }

        private static Stream PreProcessFile(string filePath, string defaultNamespace)
        {
            var parsedFile =
                File.ReadAllText(filePath, Encoding.UTF8);

            parsedFile = parsedFile.Replace(defaultNamespace, "﻿$safeprojectname$").Replace(">..\\..\\packages", ">..\\packages");
            //var ms =
            //    new MemoryStream(
            //       new UTF8Encoding(true).GetBytes(parsedFile)) {Position = 0};


            //return ms;
            var memoryStream = new MemoryStream();
            var sw = new StreamWriter(memoryStream, Encoding.UTF8);
            sw.Write(parsedFile);
            sw.Flush();
            memoryStream.Position = 0;
            return memoryStream;
        }
    }
}