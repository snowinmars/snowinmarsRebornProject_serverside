namespace Simr.WebApp.Controllers
{
    using System;
    using System.Web.Http;

    using Simr.IServices;
    using Simr.WebApp.Helpers;
    using Simr.WebApp.Models;
    using Simr.WebApp.Models.User.Read;

    public class UserController : ApiController
    {
        public UserController(IUserService userService)
        {
            this.UserService = userService;
        }

        private IUserService UserService { get; }

        [HttpGet]
        public string Get(Guid id)
        {
            var user = this.UserService.Get(id);

            var model = user.ToUserGridModel();

            return new Response<UserGridModel>(model).ToJson();
        }

        [HttpGet]
        public string Filter()
        {
            var users = this.UserService.Filter();

            var models = users.ToUserGridModels();

            return new EnumerableResponse<UserGridModel>(models).ToJson();
        }
    }
}