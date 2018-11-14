using System;
using System.Linq;
using System.Web.Http;

using Simr.IServices;
using Simr.WebApp.Helpers;
using Simr.WebApp.Models;
using Simr.WebApp.Models.Book.Read;

namespace Simr.WebApp.Controllers
{
    public class BookController : ApiController
    {
        public BookController(IBookService bookService)
        {
            BookService = bookService;
        }

        private IBookService BookService { get; }

        [HttpGet]
        public string Get(Guid id)
        {
            var book = BookService.Get(id);

            var model = book.ToBookGridModel();

            return new Response<BookGridModel>(model).ToJson();
        }

        [HttpPost]
        public string Filter(FilterModel filter)
        {
            var books = BookService.Filter();

            var models = books.ToBookGridModels();

            models = models.Skip(filter.Page.Number * filter.Page.Size).Take(filter.Page.Size);

            return new EnumerableResponse<BookGridModel>(models).ToJson();
        }
    }
}