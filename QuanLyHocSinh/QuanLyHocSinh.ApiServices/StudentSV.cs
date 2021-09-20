using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using QuanLyHocSinh.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinh.ApiServices
{
    public class StudentSV : BaseServices
    {
        public StudentSV(IOptions<ApiConfig> config, IHttpContextAccessor httpContext)
        {
            pConfig = config.Value;
            var cookie = httpContext.HttpContext.Request.Cookies["LoginCookieIdentity"];
            if (!string.IsNullOrEmpty(cookie))
            {
                var user = JsonConvert.DeserializeObject<UserAccount>(cookie);
                token = user.Token;
            }
        }
        public List<StudentModel> GetListStudent(int pageIndex, int pageSize)
        {
            var response = GetDataFromApiOut<List<StudentModel>>(
                "student/getallstudent",
                Method.GET,
                null,
                new List<string[]> {
                    new[]{"pageIndex",pageIndex.ToString()},
                    new[]{"pageSize",pageSize.ToString()}
                });
            return response;
        }
        public int InsertStudent(StudentModel student)
        {
            var response = GetDataFromApiOut<BaseResultAPI<int>, StudentModel>(
                "student/insertstudent",
                Method.POST,
                null,
                null,
                student);
            return response != null ? response.RowEffect : 1;
        }
        public int UpdateStudent(StudentModel student)
        {
            var response = GetDataFromApiOut<BaseResultAPI<int>, StudentModel>(
                "student/updatestudent",
                Method.POST,
                null,
                null,
                student);
            return response != null ? response.RowEffect : 1;
        }
        public int DeleteStudent(int id)
        {
            var response = GetDataFromApiOut<BaseResultAPI<int>,int>(
                "student/deletestudent",
                Method.POST,
                null,
                new List<string[]> {
                    new[]{"id",id.ToString()}
                });
            return response != null ? response.RowEffect : 1;
        }
        public StudentModel GetStudentById(int id)
        {
            var response = GetDataFromApiOut<StudentModel>(
                "student/getstudentbyid",
                Method.GET,
                null,
                new List<string[]> {
                    new[]{"id",id.ToString()}
                });
            return response;
        }
        public StudentModel GetStudentByEmail(string email)
        {
            var response = GetDataFromApiOut<StudentModel>(
                "student/getstudentbyemail",
                Method.GET,
                null,
                new List<string[]> {
                    new[]{"email",email}
                });
            return response;
        }
    }

  
}
