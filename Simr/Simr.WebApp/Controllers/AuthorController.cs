using System;
using System.Web.Http;

using Simr.IServices;
using Simr.WebApp.Helpers;
using Simr.WebApp.Models;
using Simr.WebApp.Models.Author.Read;

namespace Simr.WebApp.Controllers
{
    public class AuthorController : ApiController
    {
        public AuthorController(IAuthorService authorService)
        {
            AuthorService = authorService;
        }

        private IAuthorService AuthorService { get; }

        [HttpGet]
        public string Get(Guid id)
        {
            var author = AuthorService.Get(id);

            var model = author.ToAuthorGridModel();

            return new Response<AuthorGridModel>(model).ToJson();
        }

        [HttpPost]
        public string Filter()
        {
            var authors = AuthorService.Filter();

            var models = authors.ToAuthorGridModels();

            return new EnumerableResponse<AuthorGridModel>(models).ToJson();
        }
    }
}