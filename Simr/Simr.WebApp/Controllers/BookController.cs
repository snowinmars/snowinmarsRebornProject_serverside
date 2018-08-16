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
using Simr.WebApp.Models.Book.Read;

namespace Simr.WebApp.Controllers
{
    public class BookController : ApiController
    {
        public BookController()
        {
            this.BookService = new BookService();
        }

        public IBookService BookService { get; set; }

        [HttpGet]
        public string Get(Guid id)
        {
            var book = BookService.Get(id);

            var model = book.ToBookGridModel();

            return new Response<BookGridModel>(model).ToJson();
        }

        [HttpPost, HttpOptions]
        public string Filter()
        {
            var books = BookService.Filter();

            var models = books.ToBookGridModels();

            return new EnumerableResponse<BookGridModel>(models).ToJson();
        }
    }
}
