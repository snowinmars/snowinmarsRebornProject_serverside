using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Newtonsoft.Json;

namespace Simr.WebApp.Models.PersonName
{
    public class PersonNameModel : Model
    {
        [JsonProperty("familyName")]
        public string FamilyName { get; set; }
        [JsonProperty("fullMiddleName")]
        public string FullMiddleName { get; set; }
        [JsonProperty("givenName")]
        public string GivenName { get; set; }
    }
}