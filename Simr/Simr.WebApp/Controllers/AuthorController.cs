namespace Simr.WebApp.Controllers
{
    using System;
    using System.Web.Http;

    using Simr.IServices;
    using Simr.Services;
    using Simr.WebApp.Helpers;
    using Simr.WebApp.Models;
    using Simr.WebApp.Models.Author.Read;

    public class AuthorController : ApiController
    {
        public AuthorController()
        {
            this.AuthorService = new AuthorService();
        }

        public IAuthorService AuthorService { get; set; }

        [HttpOptions]
        [ActionName("Get")]
        public string GetOptions()
        {
            return "";
        }

        [HttpGet]
        [ActionName("Get")]
        public string GetPost([FromBody]Guid id)
        {
            var author = this.AuthorService.Get(id);

            var model = author.ToAuthorGridModel();

            return new Response<AuthorGridModel>(model).ToJson();
        }

        [HttpPost]
        public string Filter()
        {
            var authors = this.AuthorService.Filter();

            var models = authors.ToAuthorGridModels();

            return new EnumerableResponse<AuthorGridModel>(models).ToJson();
        }
    }
}