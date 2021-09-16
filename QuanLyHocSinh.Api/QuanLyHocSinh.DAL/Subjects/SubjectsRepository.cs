using Dapper;
using QuanLyHocSinh.DTO.Subjects;
using QuanLyHocSinh.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinh.DAL.Subjects
{
    public class SubjectsRepository : ISubjectsRepository
    {
        private readonly Dapper.Dapper _dapper;
        public SubjectsRepository(Dapper.Dapper dapper)
        {
            _dapper = dapper;
        }
        public int DeleteSubject(int id)
        {
            var output = _dapper.ExecuteNonQueryWithOutObject(
               "Duong_SP_Subject_D",
               "@Id", id,
               "@RowEffect|out", 0);

            return int.Parse((output != null && output.Any()) ? output[0].Value : "0");
        }

        public List<SubjectsModel> GetAllSubjects(int pageIndex, int pageSize)
        {
            var dbParams = new DynamicParameters();
            dbParams.Add("@PageIndex", pageIndex);
            dbParams.Add("@PageSize", pageSize);
            return _dapper.GetList<SubjectsModel>("Duong_SP_GetAllSubjects", dbParams);
        }

        public SubjectsModel GetSubjectsById(int id)
        {
            var dbParams = new DynamicParameters();
            dbParams.Add("@Id", id);
            return _dapper.Get<SubjectsModel>("Duong_SP_GetSubjectsByID", dbParams);
        }

        public int InsertSubjects(SubjectsModel subjects)
        {
            var output = _dapper.ExecuteNonQueryWithOutObject(
                "Duong_SP_Subject_I",
                "@SubjectsName", subjects.SubjectName,
                "@RowEffect|out", 0);
            return int.Parse((output != null && output.Any()) ? output[0].Value : "0");
        }

        public int UpdateSubjects(SubjectsModel subjects)
        {
            var output = _dapper.ExecuteNonQueryWithOutObject(
                "Duong_SP_Subject_U",
                "ID", subjects.ID,
                "@SubjectsName", subjects.SubjectName,
                "@RowEffect|out", 0);
            return int.Parse((output != null && output.Any()) ? output[0].Value : "0");
        }
    }
}
