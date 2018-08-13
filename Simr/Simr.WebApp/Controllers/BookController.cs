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
    using Simr.WebApp.Models.Book;

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

            var model = book.ToBookBase_ReadModel();

            return new Response<BookBase_ReadModel>(model).ToJson();
        }

        [HttpOptions]
        [ActionName("Filter")]
        public string FilterOptions()
        {
            return "ok";
        }

        [HttpPost]
        [ActionName("Filter")]
        public string FilterPost()
        {
            var books = BookService.Filter();

            var model = books.ConvertArray(ConvertHelper.ToBookBase_ReadModel);

            return new Response<BookBase_ReadModel[]>(model).ToJson();
        }
    }
}
