using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace ConsoleApplication8
{
    class Program
    {
        static void Main()
        {
            var config = new HttpSelfHostConfiguration("http://localhost:8080");

            config.Routes.MapHttpRoute(
                "API Default", "api/{controller}/{id}",
                new { id = RouteParameter.Optional });

            using (var server = new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();

                Console.WriteLine("Press Enter to quit.");
                Console.ReadLine();
            }
        }
    }

    public class ValuesController : ApiController
    {
        // POST /api/values
        public Task<string> Post()
        {
            return this.ControllerContext.Request.Content.ReadAsStringAsync();
        }
    }

    public class ValuesAsyncController : ApiController
    {
        public async Task<string> Post()
        {
            return await this.ControllerContext.Request.Content.ReadAsStringAsync();
        }
    }
}
