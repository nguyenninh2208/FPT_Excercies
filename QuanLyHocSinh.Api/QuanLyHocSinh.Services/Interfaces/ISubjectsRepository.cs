using QuanLyHocSinh.DTO.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinh.Services.Interfaces
{
   public interface ISubjectsRepository
    {
        public SubjectsModel GetSubjectsById(int id);
        public List<SubjectsModel> GetAllSubjects(int pageIndex, int pageSize);
        public int InsertSubjects(SubjectsModel subjects);
        public int UpdateSubjects(SubjectsModel subjects);
        public int DeleteSubject(int id);
    }
}
