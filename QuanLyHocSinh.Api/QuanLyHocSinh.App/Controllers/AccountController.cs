using Microsoft.AspNetCore.Mvc;
using QuanLyHocSinh.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyHocSinh.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiAuthorize.ApiAuthorize]
    public class AccountController : ControllerBase
    {
        private readonly IUserAccountRepository _userAccRepos;
        public AccountController(IUserAccountRepository userAccount)
        {
            _userAccRepos = userAccount;
        }

        [HttpGet("getuseraccount")]
        public IActionResult GetUserAccountByUserName(string userName)
        {
            var result = _userAccRepos.GetUserAccountByUserName(userName);
            return Ok(result);
        }

        [HttpPost("insertusertoken")]
        public IActionResult InsertUserToken(int userId, string token)
        {
           var result = _userAccRepos.InsertUserToken(userId, token);
            return Ok(new { IsSuccessfull = true, RowEffect = result });
        }
    }
}
