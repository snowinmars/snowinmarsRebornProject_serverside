using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

using System.Web.Http;

using Newtonsoft.Json;

using Simr.IServices;
using Simr.WebApp.Helpers;
using Simr.WebApp.Models;
using Simr.WebApp.Models.Siberia.Read;
using Simr.WebApp.Models.Siberia.Write;

namespace Simr.WebApp.Controllers
{
    public class SiberiaController : ApiController
    {
        private ISiberiaService SiberiaService { get; }

        public SiberiaController(ISiberiaService siberiaService)
        {
            SiberiaService = siberiaService;
        }

        [HttpPost]
        public string Filter()
        {
            var environments = SiberiaService.Filter();

            var environmentModels = environments.Select(x => x.ToSiberiaEnvironmentGridModels()).ToArray();

            return new Response<SiberiaEnvironmentGridModel[]>(environmentModels).ToJson();
        }

        [HttpPost]
        public string Add(SiberiaEnvironmentWriteModel model)
        {
            var environment = model.ToSiberiaEnvironment();

            SiberiaService.Add(environment);

            return new Response<int>(1).ToJson(); // TODO: [DT] 
        }

        [HttpPost]
        public string Update(SiberiaEnvironmentWriteModel model)
        {
            var environment = model.ToSiberiaEnvironment();

            SiberiaService.Update(environment);

            return new Response<int>(1).ToJson(); // TODO: [DT] 
        }

        [HttpPost]
        public string Upsert(SiberiaEnvironmentWriteModel model)
        {
            var environment = model.ToSiberiaEnvironment();

            SiberiaService.Upsert(environment);

            return new Response<int>(1).ToJson(); // TODO: [DT] 
        }

        [HttpPost]
        public string Delete([FromBody]Guid id)
        {
            SiberiaService.Delete(id);

            return new Response<int>(1).ToJson(); // TODO: [DT] 
        }
    }
}