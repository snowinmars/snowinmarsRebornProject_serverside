using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Simr.IServices;
using Simr.Services;
using Simr.WebApp.Models;

namespace Simr.WebApp.Controllers
{
    public class TextBeautifierController : ApiController
    {
        public TextBeautifierController()
        {
            this.TextBeautifierService = new TextBeautifierService();
        }

        public TextBeautifierService TextBeautifierService { get; set; }

        [HttpGet]
        public string Index(string input)
        {
            var result = TextBeautifierService.Beautify(input.ToLowerInvariant(), Sirb.Common.Enums.Language.Ru, Sirb.Common.Enums.Language.Talib);

            return new Response<string>(result).ToJson();
        }
    }
}
