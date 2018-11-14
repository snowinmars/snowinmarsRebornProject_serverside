using Newtonsoft.Json;

namespace Simr.WebApp.Models
{
    public class Response<T> : IResponse<T>
    {
        public Response(T data)
        {
            Data = data;
        }

        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("isSuccess ")]
        public bool IsSuccess => Code == 0;

        [JsonProperty("data")]
        public T Data { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}