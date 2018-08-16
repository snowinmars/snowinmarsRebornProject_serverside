using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Simr.IServices;
using Simr.Services;
using Simr.WebApp.Models;
using Simr.WebApp.Helpers;
using Simr.WebApp.Models.Author.Read;

namespace Simr.WebApp.Controllers
{
    public class AuthorController : ApiController
    {
        public AuthorController()
        {
            this.AuthorService = new AuthorService();
        }

        public IAuthorService AuthorService { get; set; }

        [HttpGet]
        public string Get(Guid id)
        {
            var author = AuthorService.Get(id);

            var model = author.ToAuthorGridModel();

            return new Response<AuthorGridModel>(model).ToJson();
        }

        [HttpGet]
        public string Filter()
        {
            var authors = AuthorService.Filter();

            var models = authors.ToAuthorGridModels();

            return new EnumerableResponse<AuthorGridModel>(models).ToJson();
        }
    }
}
