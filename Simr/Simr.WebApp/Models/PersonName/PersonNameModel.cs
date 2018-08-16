namespace Simr.WebApp.Models.PersonName
{
    using Newtonsoft.Json;

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