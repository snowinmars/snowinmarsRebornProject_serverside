using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ninject;

using Simr.DataLayer;
using Simr.IDataLayer;
using Simr.IServices;
using Simr.Services;

namespace Simr.Ninject
{
    public static class Resolver
    {
        public static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IAuthorService>().To<AuthorService>();
            kernel.Bind<IBookService>().To<BookService>();

            kernel.Bind<IUserDataLayer>().To<UserDataLayer>();
            kernel.Bind<IAuthorDataLayer>().To<AuthorDataLayer>();
            kernel.Bind<IBookDataLayer>().To<BookDataLayer>();
        }
    }
}
