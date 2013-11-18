namespace Nancy.Templates.Builder.Model
{
    public class Template
    {
        public  string          ProjectFileName     { get; set; }
        public  string          ProjectName         { get; set; }
        public  string          Name                { get; set; }
        public  string          Description         { get; set; }
        public  string          TargetPath          { get; set; }
        public  string          ProjectType         { get; set; }
        public  TemplateFile[]  Files               { get; set; }
        public  TemplateFolder  ProjectFolder       { get; set; }
        
    }
}