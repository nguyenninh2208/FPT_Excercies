using Microsoft.AspNetCore.Mvc;
using QuanLyHocSinh.Services.Interfaces;
using QuanLyHocSinh.App.Extentsions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Caching.Distributed;
using QuanLyHocSinh.DTO.Account;
using System.Diagnostics;
using System.Security.Claims;

namespace QuanLyHocSinh.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ApiAuthorize.ApiAuthorize]
    public class AccountController : ControllerBase
    {
        private readonly IUserAccountRepository _userAccRepos;
        private readonly IConfiguration _configuration;
        private readonly IDistributedCache _cache;
        public AccountController(IUserAccountRepository userAccount, IConfiguration configuration, IDistributedCache cache)
        {
            _userAccRepos = userAccount;
            _configuration = configuration;
            _cache = cache;
        }

        //[HttpGet("getuseraccount")]
        //public IActionResult GetUserAccountByUserName(string userName)
        //{
        //    var result = _userAccRepos.GetUserAccountByUserName(userName);
        //    return Ok(result);
        //}

        //[HttpPost("insertusertoken")]
        //public IActionResult InsertUserToken(int userId, string token)
        //{
        //   var result = _userAccRepos.InsertUserToken(userId, token);
        //    return Ok(new { IsSuccessfull = true, RowEffect = result });
        //}

        [HttpPost("userauth")]
        public IActionResult UserAuth(string userName, string password)
        {
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                string hash = password.ToMD5Hash();
                var user = _userAccRepos.UserAuth(userName, hash);

                if (user is null)
                {
                    return Ok(user);
                }

                string token = GenerateWebToken(user);
                _userAccRepos.InsertUserToken(user.UserID, token);

                user.Token = token;

                _cache.SetUser(token, user);
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }

        private string GenerateWebToken(UserAccount userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim("Id", userInfo.UserID.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, DateTime.Now.AddMinutes(20).ToString())

            };

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
