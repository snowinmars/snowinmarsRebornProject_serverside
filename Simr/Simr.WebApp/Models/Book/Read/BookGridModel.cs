using System.Collections.Generic;

using Newtonsoft.Json;

using Simr.Common.Enums;
using Simr.WebApp.Models.Author.Read;

namespace Simr.WebApp.Models.Book.Read
{
    public class BookGridModel : Model
    {
        public BookGridModel()
        {
            Authors = new List<AuthorGridModel>();
        }

        [JsonProperty("status")]
        public BookStatus Status { get; set; }

        [JsonProperty("additionalInfo")]
        public string AdditionalInfo { get; set; }

        [JsonProperty("authors")]
        public List<AuthorGridModel> Authors { get; }

        [JsonProperty("bookshelf")]
        public string Bookshelf { get; set; }

        [JsonProperty("flibustaUrl")]
        public string FlibustaUrl { get; set; }

        [JsonProperty("libRusEcUrl")]
        public string LibRusEcUrl { get; set; }

        [JsonProperty("liveLibUrl")]
        public string LiveLibUrl { get; set; }

        [JsonProperty("owner")]
        public string Owner { get; set; }

        [JsonProperty("pageCount")]
        public int PageCount { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }
    }
}