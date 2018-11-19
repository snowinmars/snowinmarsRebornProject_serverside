using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Simr.Common.Enums;
using Simr.IServices;
using Simr.WebApp.Models;

namespace Simr.WebApp.Controllers
{
    public class TextBeautifierController : ApiController
    {
        public TextBeautifierController(ITextBeautifierService textBeautifierService)
        {
            this.TextBeautifierService = textBeautifierService;
        }

        public ITextBeautifierService TextBeautifierService { get; set; }

        [HttpGet]
        public string Index(string input)
        {
            var result = TextBeautifierService.Beautify(input.ToLowerInvariant(), Language.Ru, Language.Talib);

            return new Response<string>(result).ToJson();
        }
    }
}
