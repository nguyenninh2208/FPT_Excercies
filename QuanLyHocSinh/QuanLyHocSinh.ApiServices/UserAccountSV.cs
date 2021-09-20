using Microsoft.Extensions.Options;
using QuanLyHocSinh.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinh.ApiServices
{
    public class UserAccountSV : BaseServices
    {
        public UserAccountSV(IOptions<ApiConfig> config)
        {
            pConfig = config.Value;
        }

        public UserAccount GetUserAccountByName(string userName)
        {
            var output = GetDataFromApiOut<UserAccount>(
                "account/getuseraccount",
                Method.GET,
                null,
                new List<string[]>
                {
                    new[] {"userName",userName}
                });
            return output;
        }

        public int InsertUserToken(int userId, string token)
        {
            var response = GetDataFromApiOut<BaseResultAPI<int>>(
                  "account/insertusertoken",
                  Method.POST,
                  null,
                  new List<string[]>
                  {
                    new[] {"userId",userId.ToString()},
                    new[]{"token",token}
                  });

            return response != null ? response.RowEffect : 1;
        }
        public UserAccount UserAuth(string userName, string password)
        {

            var output = GetDataFromApiOut<UserAccount>(
                "account/userauth",
                Method.POST,
                null,
                new List<string[]>
                {
                    new[] {"userName",userName},
                    new[]{"password",password}
                });
            return output;
        }
    }
}
