using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Newtonsoft.Json;

namespace Simr.WebApp.Models.Siberia.Write
{
    public class SiberiaEnvironmentWriteModel : Model
    {
        [JsonProperty("environment")]
        public string Environment { get; set; }

        [JsonProperty("branch")]
        public string Branch { get; set; }
    }
}