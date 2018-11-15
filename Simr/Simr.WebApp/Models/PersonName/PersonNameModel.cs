using Newtonsoft.Json;

namespace Simr.WebApp.Models.PersonName
{
    public class PersonNameModel
    {
        [JsonProperty("familyName")]
        public string FamilyName { get; set; }

        [JsonProperty("fullMiddleName")]
        public string FullMiddleName { get; set; }

        [JsonProperty("givenName")]
        public string GivenName { get; set; }
    }
}