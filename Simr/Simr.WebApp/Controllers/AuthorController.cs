using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Simr.WebApp.Controllers
{
    using Simr.IServices;
    using Simr.Services;
    using Simr.WebApp.Models;
    using Simr.WebApp.Models.Author;

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

            var model = author.ToAuthorBase_ReadModel();

            return new Response<AuthorBase_ReadModel>(model).ToJson();
        }

        [HttpGet]
        public string Filter()
        {
            var authors = AuthorService.Filter();

            var model = authors.ConvertArray(ConvertHelper.ToAuthorBase_ReadModel);

            return new Response<AuthorBase_ReadModel[]>(model).ToJson();
        }
    }
}
