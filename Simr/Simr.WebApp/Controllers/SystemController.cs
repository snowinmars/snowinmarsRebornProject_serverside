using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Newtonsoft.Json;

namespace Simr.WebApp.Controllers
{
    public class SystemController : ApiController
    {
        [HttpPost, HttpOptions]
        public string Version()
        {
            return JsonConvert.SerializeObject(new
            {
                Backend = "0.1.0",
            });
        }
    }
}
