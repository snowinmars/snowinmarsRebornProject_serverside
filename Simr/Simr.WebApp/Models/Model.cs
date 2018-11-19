using System;

using Newtonsoft.Json;

namespace Simr.WebApp.Models
{
    public abstract class Model
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("key")]
        public string Key => Id.ToString();
    }
}