using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using QuanLyHocSinh.ApiServices;
using QuanLyHocSinh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace QuanLyHocSinh.App.Controllers
{
    [Route("auth")]
    public class AccountController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly UserAccountSV _accountSV;
        private readonly StudentSV _studentSV;
        public AccountController(IConfiguration configuration, UserAccountSV accountSV, StudentSV studentSV)
        {
            _configuration = configuration;
            _accountSV = accountSV;
            _studentSV = studentSV;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Route("login")]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl)) returnUrl = "/home/index";
            if (User.Identity.IsAuthenticated)
            {
                var cookie = HttpContext.Request.Cookies["LoginCookieIdentity"];
                if (cookie != null)
                {
                    var user = JsonConvert.DeserializeObject<UserAccount>(cookie);
                    string token = Guid.NewGuid().ToString();
                    _accountSV.InsertUserToken(user.UserID, token);
                }

                return Redirect(WebUtility.HtmlDecode(returnUrl));
            }
            if (TempData.ContainsKey("Message")) ViewBag.Message = TempData["Message"];
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [Route("login")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LoginForm(LoginModel model)
        {
            try
            {
                var user = _accountSV.GetUserAccountByName(model.UserName);
                if (user != null)
                {
                    var isPswMatch = user.Password.Equals(model.Password);
                    if (isPswMatch)
                    {
                        UserLogin(user);

                        string token = Guid.NewGuid().ToString();
                        _accountSV.InsertUserToken(user.UserID, token);

                        return Ok(new { success = true, returnUrl = model.ReturnUrl });
                    }
                }
                return Ok(new { success = false, message = "Tên đăng nhập hoặc mật khẩu không đúng." });
            }
            catch
            {

            }
            return Ok(new { success = false, message = "Đăng nhật thất bại." });
        }

        private void UserLogin(UserAccount user)
        {
            var properties = new AuthenticationProperties
            {
                AllowRefresh = false,
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
            };

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,user.UserID.ToString()),
                new Claim(ClaimTypes.Name,user.Name.ToString()),
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            var cookie = HttpContext.Request.Cookies["LoginCookieIdentity"];
            if (cookie == null)
            {
                HttpContext.Response.Cookies.Append("LoginCookieIdentity", JsonConvert.SerializeObject(user));
            }
            else
            {
                HttpContext.Response.Cookies.Delete("LoginCookieIdentity");
                HttpContext.Response.Cookies.Append("LoginCookieIdentity", JsonConvert.SerializeObject(user));
            }

            HttpContext.SignInAsync(principal, properties);
        }

        [Route("logout")]
        [HttpPost]
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync();
            return Redirect("/auth/login");
        }

        #region google login
        [Route("googlelogin")]
        public IActionResult GetLoginGoogle()
        {
            var properties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleResponse") };

            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }
        [Route("google-response")]
        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");

            //var claims = result.Principal.Identities
            //    .FirstOrDefault().Claims.Select(claim => new
            //    {
            //        claim.Issuer,
            //        claim.OriginalIssuer,
            //        claim.Type,
            //        claim.Value
            //    });

            //var email = claims.Last().Value;
            //var user = _studentSV.GetStudentByEmail(email);



            //if (user != null)
            //{
            //    var userAccount = new UserAccount() { UserID = user.ID };
            //    UserLogin(userAccount);

            //    return RedirectToAction("Index", "Home");
            //}
            //else
            //{
            //    //await HttpContext.SignOutAsync();
            //    //TempData["Message"] = "Tài khoản email chưa được đăng ký";
            //    return  RedirectToAction("Login", "Account");
            //}
        }
        #endregion
    }
}
