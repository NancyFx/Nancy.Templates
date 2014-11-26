namespace Nancy.Templates.CSharp.AspNetHost
{
    using Nancy;
    using Nancy.Hosting.Aspnet;

    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = parameters => {
                return View["index"];
            };
        }
    }
}