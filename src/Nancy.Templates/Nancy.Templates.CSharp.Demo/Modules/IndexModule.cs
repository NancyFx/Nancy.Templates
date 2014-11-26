namespace Nancy.Templates.CSharp.Demo.Modules
{
    using Nancy;
    using Nancy.Hosting.Aspnet;

    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = _ => View["index"];
        }
    }
}