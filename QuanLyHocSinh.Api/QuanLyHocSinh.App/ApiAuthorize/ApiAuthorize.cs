using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Distributed;
using QuanLyHocSinh.App.Extentsions;
using QuanLyHocSinh.DTO.Account;
using QuanLyHocSinh.Services.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;

namespace QuanLyHocSinh.App.ApiAuthorize
{
    public class ApiAuthorize : ActionFilterAttribute
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

                var expClams = jwtToken.Claims.FirstOrDefault(x => x.Type == "exp").Value;
                var tokenExp = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(Convert.ToDouble(expClams)).ToLocalTime();

                if (tokenExp < DateTime.Now) //het han
                {
                    actionContext.Result = new ObjectResult(null) { StatusCode = (int)HttpStatusCode.Unauthorized };
                }
                else
                {
                    var user = cacheService.GetUser<UserAccount>(token); // lay cache
                    if (user is null)
                    {
                        string userName = jwtToken.Claims.FirstOrDefault(x => x.Type == "sub").Value;
                        var userService = (IUserAccountRepository)sv.GetService(typeof(IUserAccountRepository));
                        user = userService.GetUserAccountByUserName(userName);
                        if (user is null)
                        {
                            actionContext.Result = new ObjectResult(null) { StatusCode = (int)HttpStatusCode.Unauthorized };
                        }
                        else
                        {
                            cacheService.SetUser(user.Token, user);
                        }
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
