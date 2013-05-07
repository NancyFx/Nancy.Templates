namespace Nancy.Templates.CSharp.AspNetHost
{
    using Nancy;

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