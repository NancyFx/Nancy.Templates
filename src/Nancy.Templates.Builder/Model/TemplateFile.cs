namespace Nancy.Templates.Builder.Model
{
    public class TemplateFile
    {
        public  string  Name                { get; set; }
        public  string  FilePath            { get; set; }
        public  string  ZipPath             { get; set; }
        public  bool    Exclude             { get; set; }
        public  bool    ReplaceParameters   { get; set; }
    }
}