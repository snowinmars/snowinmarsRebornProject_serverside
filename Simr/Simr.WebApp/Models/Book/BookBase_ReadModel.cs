using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Simr.WebApp.Models.Book
{
    using Newtonsoft.Json;

    using Simr.WebApp.Models.Author;

    using Sirb.Common.Enums;

    public class BookBase_ReadModel
    {
        public BookBase_ReadModel()
        {
            Authors = new List<AuthorBase_ReadModel>();
        }

        [JsonProperty("status")]
        public BookStatus Status { get; set; }

        [JsonProperty("additionalInfo")]
        public string AdditionalInfo { get; set; }

        [JsonProperty("authors")]
        public List<AuthorBase_ReadModel> Authors { get; }

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
    }
}