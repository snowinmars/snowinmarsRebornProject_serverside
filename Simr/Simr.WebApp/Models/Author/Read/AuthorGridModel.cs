namespace Simr.WebApp.Models.Author.Read
{
    using Newtonsoft.Json;

    using Simr.WebApp.Models.PersonName;

    public class AuthorGridModel : Model
    {
        [JsonProperty("name")]
        public PersonNameModel Name { get; set; }

        [JsonProperty("pseudonym")]
        public PersonNameModel Pseudonym { get; set; }

        [JsonProperty("aka")]
        public string Aka { get; set; }
    }
}