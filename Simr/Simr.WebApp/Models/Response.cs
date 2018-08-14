﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Simr.WebApp.Models
{
    using Newtonsoft.Json;

    public class Response<T>
    {
        public Response(T data)
        {
            this.Data = data;
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