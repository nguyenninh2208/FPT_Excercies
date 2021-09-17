using QuanLyHocSinh.DTO.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinh.Services.Interfaces
{
  public  interface IStudentRepository
    {
        List<StudentModel> GetAllStudent(int pageIndex, int pageSize);
        int InsertStudent(StudentModel student);
        int UpdateStudent(StudentModel student);
        int DeleteStudent(int id);
        StudentModel GetStudentById(int id);
        StudentModel GetStudentByEmail(string email);
    }
}
