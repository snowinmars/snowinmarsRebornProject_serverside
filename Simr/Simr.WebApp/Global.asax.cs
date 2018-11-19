using System;
using System.Web;
using System.Web.Http;

namespace Simr.WebApp
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var response = HttpContext.Current.Response;
            var request = HttpContext.Current.Request;

            var origin = request.Headers["Origin"];

            if (origin != null)
            {
                response.AppendHeader("Access-Control-Allow-Origin", origin);
                response.AppendHeader("Access-Control-Allow-Credentials", "true");
                response.AppendHeader("Access-Control-Allow-Headers", "Content-Type, X-CSRF-Token, X-Requested-With, Accept, Accept-Version, Content-Length, Content-MD5, Date, X-Api-Version, X-File-Name");
                response.AppendHeader("Access-Control-Allow-Methods", "POST,GET,PUT,PATCH,DELETE,OPTIONS");
            }

            if (request.HttpMethod == "OPTIONS")
            {
                response.StatusCode = 200;
                response.End();
            }
        }
    }
}