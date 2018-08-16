using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Simr.IServices;
using Simr.Services;
using Simr.WebApp.Helpers;
using Simr.WebApp.Models;
using Simr.WebApp.Models.User.Read;

namespace Simr.WebApp.Controllers
{
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

            var model = user.ToUserGridModel();

            return new Response<UserGridModel>(model).ToJson();
        }

        [HttpGet]
        public string Filter()
        {
            var users = UserService.Filter();

            var models = users.ToUserGridModels();

            return new EnumerableResponse<UserGridModel>(models).ToJson();
        }
    }
}
