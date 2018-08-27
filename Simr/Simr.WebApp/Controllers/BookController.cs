using System.Linq;

namespace Simr.WebApp.Controllers
{
    using System;
    using System.Threading;
    using System.Web.Http;

    using Simr.IServices;
    using Simr.Services;
    using Simr.WebApp.Helpers;
    using Simr.WebApp.Models;
    using Simr.WebApp.Models.Book.Read;

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
            var book = this.BookService.Get(id);

            var model = book.ToBookGridModel();

            return new Response<BookGridModel>(model).ToJson();
        }

        [HttpOptions]
        [ActionName("Filter")]
        public string FilterOptions()
        {
            return "";
        }

        [HttpPost]
        [ActionName("Filter")]
        public string FilterPost([FromBody]FilterModel filter)
        {
            var books = this.BookService.Filter();

            var models = books.ToBookGridModels();

            models = models.Skip(filter.Page.Number * filter.Page.Size).Take(filter.Page.Size);

            return new EnumerableResponse<BookGridModel>(models).ToJson();
        }
    }
}