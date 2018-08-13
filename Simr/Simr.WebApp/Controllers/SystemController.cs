using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Simr.WebApp.Controllers
{
    using Newtonsoft.Json;

    public class SystemController : ApiController
    {
        [HttpOptions]
        [ActionName("Version")]
        public string VersionOptions()
        {
            return "ok";
        }

        [HttpPost]
        [ActionName("Version")]
        public string VersionPost()
        {
            return JsonConvert.SerializeObject(new
                                                   {
                                                       Backend = "0.0.1",
                                                   });

        }
    }
}
