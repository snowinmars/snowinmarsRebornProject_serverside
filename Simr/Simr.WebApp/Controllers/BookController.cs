using System.Linq;

namespace Simr.WebApp.Controllers
{
    using System;
    using System.Threading;
    using System.Web.Http;

    using Simr.IServices;
    using Simr.WebApp.Helpers;
    using Simr.WebApp.Models;
    using Simr.WebApp.Models.Book.Read;

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
            var book = this.BookService.Get(id);

            var model = book.ToBookGridModel();

            return new Response<BookGridModel>(model).ToJson();
        }

        [HttpPost]
        public string Filter(FilterModel filter)
        {
            var books = this.BookService.Filter();

            var models = books.ToBookGridModels();

            models = models.Skip(filter.Page.Number * filter.Page.Size).Take(filter.Page.Size);

            return new EnumerableResponse<BookGridModel>(models).ToJson();
        }
    }
}