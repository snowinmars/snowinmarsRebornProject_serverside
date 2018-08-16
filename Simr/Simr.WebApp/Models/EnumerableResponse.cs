namespace Simr.WebApp.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using Newtonsoft.Json;

    public class EnumerableResponse<T> : IResponse<T[]>
    {
        public EnumerableResponse(IEnumerable<T> data)
        {
            this.Data = data.ToArray();
        }

        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("isSuccess ")]
        public bool IsSuccess => this.Code == 0;

        [JsonProperty("data")]
        public T[] Data { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}