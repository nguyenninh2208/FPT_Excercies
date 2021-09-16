using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using QuanLyHocSinh.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace QuanLyHocSinh.App.ApiAuthorize
{
    public class ApiAuthorize: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            var sv = actionContext.HttpContext.RequestServices;
            var configService = (IConfiguration)sv.GetService(typeof(IConfiguration));
            var config = configService.GetSection("WebAPIConfig").Get<WebApiConfig>();
            try
            {
                var user = actionContext.HttpContext.Request.Headers["UserName"];

                string pass = actionContext.HttpContext.Request.Headers["Password"];

                if (!(user == config.UserName &&
                      pass == config.Password))
                {
                    //actionContext.HttpContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                    actionContext.Result = new ObjectResult(null) { StatusCode = (int)HttpStatusCode.Unauthorized };
                }
            }
            catch (Exception e)
            {
                actionContext.Result = new ObjectResult(null) { StatusCode = (int)HttpStatusCode.Unauthorized };
            }

        }
    }
}
