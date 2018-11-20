using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Newtonsoft.Json;

namespace Simr.WebApp.Models.Siberia.Read
{
    public class SiberiaEnvironmentGridModel : Model
    {
        [JsonProperty("name")]
        public string Environment { get; set; }

        [JsonProperty("environment")]
        public string Branch { get; set; }
    }
}