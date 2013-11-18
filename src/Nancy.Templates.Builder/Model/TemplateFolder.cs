namespace Nancy.Templates.Builder.Model
{
    public class TemplateFolder
    {
        public string           Name    { get; set; }
        public TemplateFolder[] Folders { get; set; }
        public TemplateFile[]   Files   { get; set; }
    }
}