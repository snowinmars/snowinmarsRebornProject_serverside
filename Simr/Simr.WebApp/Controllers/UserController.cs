using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Simr.WebApp.Controllers
{
    using System.Web.Http.Results;

    using Simr.IServices;
    using Simr.Services;
    using Simr.WebApp.Models;
    using Simr.WebApp.Models.User;

    public class UserController : ApiController
    {
        public UserController()
        {
            this.UserService = new UserService();
        }

        private IUserService UserService { get; }

        [HttpGet]
        public string Get(Guid id)
        {
            var user = UserService.Get(id);

            var model = user.ToUserBase_ReadModel();

            return new Response<UserBase_ReadModel>(model).ToJson();
        }

        [HttpGet]
        public string Filter()
        {
            var users = UserService.Filter();

            var model = users.ConvertArray(ConvertHelper.ToUserBase_ReadModel);

            return new Response<UserBase_ReadModel[]>(model).ToJson();
        }
    }
}
