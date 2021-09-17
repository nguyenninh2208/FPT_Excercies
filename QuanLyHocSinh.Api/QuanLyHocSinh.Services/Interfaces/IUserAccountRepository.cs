using QuanLyHocSinh.DTO.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinh.Services.Interfaces
{
    public interface IUserAccountRepository
    {
        public UserAccount GetUserAccountByUserName(string userName);
        public int InsertUserToken(int userId, string token);
    }
}
