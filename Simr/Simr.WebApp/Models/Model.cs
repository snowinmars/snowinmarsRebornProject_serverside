using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Simr.WebApp.Models
{
    using Newtonsoft.Json;

    public abstract class Model
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("key")]
        public string Key => Id.ToString();
    }
}