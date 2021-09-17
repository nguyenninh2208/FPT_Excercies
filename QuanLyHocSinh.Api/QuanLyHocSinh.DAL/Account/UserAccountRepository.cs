using Dapper;
using QuanLyHocSinh.DTO.Account;
using QuanLyHocSinh.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinh.DAL.Account
{
    public class UserAccountRepository : IUserAccountRepository
    {
        private readonly Dapper.Dapper _dapper;
        public UserAccountRepository(Dapper.Dapper dapper)
        {
            _dapper = dapper;
        }

        public UserAccount GetUserAccountByUserName(string userName)
        {
            var dbParams = new DynamicParameters();
            dbParams.Add("@Uname", userName, DbType.String, ParameterDirection.Input);

            var result = _dapper.Get<UserAccount>(
                "Duong_SP_AccountByUserName",
                dbParams);
            return result;
        }

        public int InsertUserToken(int userId, string token)
        {
            var output = _dapper.ExecuteNonQueryWithOutObject(
                 "Duong_SP_UserToken_I",
                 "@UserId", userId,
                 "@Token", token,
                 "@RowEffect|out",0);
            return int.Parse((output != null && output.Any()) ? output[0].Value : "0");
        }
    }
}
