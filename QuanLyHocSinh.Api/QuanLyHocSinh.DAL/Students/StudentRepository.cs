using Dapper;
using QuanLyHocSinh.DTO.Students;
using QuanLyHocSinh.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace QuanLyHocSinh.DAL.Students
{
    public class StudentRepository : IStudentRepository
    {
        private readonly Dapper.Dapper _dapper;
        public StudentRepository(Dapper.Dapper dapper)
        {
            _dapper = dapper;
        }
        public int DeleteStudent(int id)
        {
            var output = _dapper.ExecuteNonQueryWithOutObject(
                "Duong_SP_Student_D",
                "@ID",id,
                "@RowEffect|out",0);

            return int.Parse((output != null && output.Any()) ? output[0].Value : "0");
        }

        public List<StudentModel> GetAllStudent(int pageIndex, int pageSize)
        {
            var dbParams = new DynamicParameters();
            dbParams.Add("@PageIndex", pageIndex);
            dbParams.Add("@PageSize", pageSize);
            return _dapper.GetList<StudentModel>("Duong_SP_GetAll_Student", dbParams);
        }

        public StudentModel GetStudentById(int id)
        {
            var dbParams = new DynamicParameters();
            dbParams.Add("@Id", id);
            return _dapper.Get<StudentModel>("Duong_SP_GetStudentByID", dbParams);
        }

        public int InsertStudent(StudentModel student)
        {

            var output = _dapper.ExecuteNonQueryWithOutObject(
                "Duong_SP_Student_I",
                "@Name", student.Name,
                "@BDay", student.B_Day,
                "@Class", student.Class,
                "@Code", student.Code,
                "@RowEffect|out", 0);

            return int.Parse((output != null && output.Any()) ? output[0].Value : "0");
        }

        public int UpdateStudent(StudentModel student)
        {
            var dbParams = new DynamicParameters();
            dbParams.Add("@Name", student.Name);
            dbParams.Add("@BDay", student.B_Day);
            dbParams.Add("@Class", student.Class);
            dbParams.Add("@RowEffect|out", 0);

            var output = _dapper.ExecuteNonQueryWithOutObject(
                  "Duong_SP_Student_U",
                  "@ID", student.ID,
                  "@Name", student.Name,
                  "@BDay", student.B_Day,
                  "@Class", student.Class,
                  "@RowEffect|out", 0);
            return int.Parse((output != null && output.Any()) ? output[0].Value : "0");
        }
    }
}
