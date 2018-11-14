namespace Simr.WebApp.Controllers
{
    using System.Web.Http;

    using Newtonsoft.Json;

    public class SystemController : ApiController
    {
        [HttpPost, HttpOptions]
        public string Version()
        {
            return JsonConvert.SerializeObject(new { Backend = "1.0.0", });
        }
    }
}