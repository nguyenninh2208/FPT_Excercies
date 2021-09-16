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
    [Obsolete]
    public class StudentSV : BaseServices
    {
        public StudentSV(IOptions<ApiConfig> config)
        {
            pConfig = config.Value;
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
    }

  
}
