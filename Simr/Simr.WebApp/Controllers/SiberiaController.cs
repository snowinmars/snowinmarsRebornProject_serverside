using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Http;

using Simr.IServices;
using Simr.WebApp.Helpers;
using Simr.WebApp.Models;
using Simr.WebApp.Models.Siberia.Read;

namespace Simr.WebApp.Controllers
{
    public class SiberiaController : ApiController
    {
        private ISiberiaService SiberiaService { get; }

        public SiberiaController(ISiberiaService siberiaService)
        {
            SiberiaService = siberiaService;
        }

        [HttpGet]
        public string Branches()
        {
            var branches = SiberiaService.Filter();

            var branchModels = branches.Select(x => x.ToSiberiaBranchGridModels()).ToArray();

            return new Response<SiberiaBranchGridModel[]>(branchModels).ToJson();
        }
    }
}