using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Newtonsoft.Json;

namespace Simr.WebApp.Models
{
    public class FilterByModel
    {
        [JsonProperty("property")]
        public string Property { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}