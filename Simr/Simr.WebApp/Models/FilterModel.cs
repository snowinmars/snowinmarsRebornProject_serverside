using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Newtonsoft.Json;

namespace Simr.WebApp.Models
{
    public class FilterModel
    {
        public FilterModel()
        {
            Page = new FilterPageModel();
        }

        [JsonProperty("page")]
        public FilterPageModel Page { get; set; }
    }
}