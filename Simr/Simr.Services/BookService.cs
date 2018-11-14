namespace Simr.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SandS.Algorithm.Library.GeneratorNamespace;

    using Sibr.Entities;
    using Simr.IDataLayer;
    using Simr.IServices;

    using Sirb.Common;
    using Sirb.Common.Enums;

    public class BookService : IBookService
    {
        public BookService(IBookDataLayer dataLayer)
        {
            DataLayer = dataLayer;
        }

        private IBookDataLayer DataLayer { get; }

        public Book[] Filter()
        {
            return DataLayer.Filter();
        }

        public Book Get(Guid id)
        {
            return DataLayer.Get(id);
        }
    }
}