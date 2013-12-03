namespace Nancy.Templates.Builder
{
    using System;
    using System.IO;
    using Extensions;
    using Model;

    /// <summary>
    /// Nancy Template Builder
    /// </summary>
    public static class Program
    {
        private static void Main()
        {
            Array.ForEach(
                StaticConfig.TemplateConfigProjects,
                CreateTemplateZipFromConfig);
        }

        private static void CreateTemplateZipFromConfig(TemplateConfig config)
        {
            try
            {
                Log("Start processing {0}", config.Name);

                if (!File.Exists(config.ProjectFileName))
                {
                    Log("Missing project file {0}", config.ProjectFileName);
                    Environment.Exit(1337);
                }

                var template =
                    config.ParseProjectFileFromConfig();

                if (template.Files == null || template.Files.Length == 0)
                {
                    Log("Failed to parse project file");
                    Environment.Exit(1337);
                }

                if (template.ProjectFolder == null)
                {
                    Log("Failed to parse project folder structure");
                    Environment.Exit(1337);
                }

                Log("Found {0} files in project", template.Files.Length);

                template.CreateTemplateZip();

                Log("Done processing {0}", config.Name);
            }
            catch (Exception ex)
            {
                Log("Error processing {0}\r\n{1}", config.Name, ex);
                Environment.Exit(1337);
            }
        }

        private static void Log(string format, params object[] args)
        {
            Console.WriteLine(
                "[{0:HH:mm:ss}] {1}",
                DateTime.Now,
                (args == null || args.Length == 0)
                    ? format
                    : string.Format(
                        format,
                        args));
        }
    }
}