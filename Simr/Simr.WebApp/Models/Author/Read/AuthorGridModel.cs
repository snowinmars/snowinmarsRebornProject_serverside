using System;

namespace Simr.WebApp.Models.Author.Read
{
    using Newtonsoft.Json;

    using Simr.WebApp.Models.PersonName;

    public class AuthorGridModel : Model
    {
        [JsonProperty("fullname")]
        public string Fullname
        {
            get { return $"{Name.GivenName} {Name.FullMiddleName} {Name.FamilyName}"; }
        }

        [JsonProperty("birthDate")]
        public DateTime BirthDate { get; set; }

        [JsonProperty("deathDate")]
        public DateTime? DeathDate { get; set; }

        [JsonProperty("name")]
        public PersonNameModel Name { get; set; }

        [JsonProperty("pseudonym")]
        public PersonNameModel Pseudonym { get; set; }

        [JsonProperty("aka")]
        public string Aka { get; set; }

        [JsonProperty("photoUrl")]
        public string PhotoUrl { get; set; }

        [JsonProperty("info")]
        public string Info { get; set; }
    }
}