namespace Nancy.Templates.Builder.Extensions
{
    using System;
    using System.IO;
    using System.IO.Compression;
    using Model;
    static class TemplateZipArchiveExtensions
    {
        public static void CreateTemplateZip(
            this Template template
            )
        {
            using (var fileStream = File.Open(
                                        template.TargetPath,
                                        FileMode.Create,
                                        FileAccess.Write,
                                        FileShare.None
                                    )
                )
            {
                using (var archive = new ZipArchive(fileStream, ZipArchiveMode.Create))
                {
                    Array.ForEach(
                        template.Files,
                        archive.AddFileEntry
                        );
                    template.AddVsMyTemplate(
                        archive
                        );
                }
            }
        }

        private static void AddFileEntry(
            this ZipArchive archive,
            TemplateFile    file
            )
        {
            var fileExists      = File.Exists(file.FilePath);
            var directoryExists = !fileExists && Directory.Exists(file.FilePath);

            if (!fileExists && !directoryExists)
            {
                Program.Log("Skipping missing folder/file {0}", file.FilePath);
                Environment.ExitCode = 1337;
                return;
            }

            var entry = archive.CreateEntry(file.ZipPath, CompressionLevel.Optimal);
            
            if (!fileExists)
                return;

            using (Stream
                source = File.OpenRead(file.FilePath),
                target = entry.Open()
                )
            {
                source.CopyTo(target);
            }
        }
    }
}
