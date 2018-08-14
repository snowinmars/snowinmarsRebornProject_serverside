using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Simr.WebApp.Models.Author
{
    using Newtonsoft.Json;

    using Simr.WebApp.Models.Pseudonym;

    public class AuthorBase_ReadModel
    {
        [JsonProperty("familyName")]
        public string FamilyName { get; set; }

        [JsonProperty("fullMiddleName")]
        public string FullMiddleName { get; set; }

        [JsonProperty("givenName")]
        public string GivenName { get; set; }

        [JsonProperty("pseudonym")]
        public PseudonymBase_ReadModel Pseudonym { get; set; }

        [JsonProperty("aka")]
        public string Aka { get; set; }
    }
}