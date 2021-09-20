using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using QuanLyHocSinh.App.Extentsions;
using QuanLyHocSinh.DTO;
using QuanLyHocSinh.DTO.Account;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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
            //var configService = (IConfiguration)sv.GetService(typeof(IConfiguration));
            //    var config = configService.GetSection("WebAPIConfig").Get<WebApiConfig>();
            var cacheService = (IDistributedCache)sv.GetService(typeof(IDistributedCache));
            try
            {
                //var user = actionContext.HttpContext.Request.Headers["UserName"];

                //string pass = actionContext.HttpContext.Request.Headers["Password"];
                string token = actionContext.HttpContext.Request.Headers["token"];

                if (token is null)
                {
                    actionContext.Result = new ObjectResult(null) { StatusCode = (int)HttpStatusCode.Unauthorized };
                }

                var jwt = new JwtSecurityTokenHandler();
                var jwtToken = jwt.ReadJwtToken(token);

                if (jwtToken.ValidTo < DateTime.Now) //het han
                {
                    actionContext.Result = new ObjectResult(null) { StatusCode = (int)HttpStatusCode.NetworkAuthenticationRequired };
                }
                else
                {
                    var user = cacheService.GetUser<UserAccount>(token);
                    if (user is null)
                    {
                        actionContext.Result = new ObjectResult(null) { StatusCode = (int)HttpStatusCode.NetworkAuthenticationRequired };
                    }
                }

                //if (!(user == config.UserName &&
                //      pass == config.Password))
                //{
                //    //actionContext.HttpContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                //    actionContext.Result = new ObjectResult(null) { StatusCode = (int)HttpStatusCode.Unauthorized };
                //}

            }
            catch (Exception e)
            {
                actionContext.Result = new ObjectResult(null) { StatusCode = (int)HttpStatusCode.Unauthorized };
            }

        }
    }
}
