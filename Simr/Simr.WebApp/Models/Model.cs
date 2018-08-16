namespace Simr.WebApp.Models
{
    using System;

    using Newtonsoft.Json;

    public abstract class Model
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("key")]
        public string Key => this.Id.ToString();
    }
}