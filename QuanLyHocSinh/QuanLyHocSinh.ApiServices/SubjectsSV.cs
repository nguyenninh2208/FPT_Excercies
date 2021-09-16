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
    public class SubjectsSV:BaseServices
    {
        public SubjectsSV(IOptions<ApiConfig> config)
        {
            pConfig = config.Value;
        }

        public List<SubjectsModel> GetListSubjects(int pageIndex, int pageSize)
        {
            var response = GetDataFromApiOut<List<SubjectsModel>>(
                "Subjects/getallsubjects",
                Method.GET,
                null,
                new List<string[]> {
                    new[]{"pageIndex",pageIndex.ToString()},
                    new[]{"pageSize",pageSize.ToString()}
                });
            return response;
        }
        public int InsertSubjects(SubjectsModel Subjects)
        {
            var response = GetDataFromApiOut<BaseResultAPI<int>, SubjectsModel>(
                "Subjects/insertsubjects",
                Method.POST,
                null,
                null,
                Subjects);
            return response != null ? response.RowEffect : 1;
        }
        public int UpdateSubjects(SubjectsModel Subjects)
        {
            var response = GetDataFromApiOut<BaseResultAPI<int>, SubjectsModel>(
                "Subjects/updatesubjects",
                Method.POST,
                null,
                null,
                Subjects);
            return response != null ? response.RowEffect : 1;
        }
        public int DeleteSubjects(int id)
        {
            var response = GetDataFromApiOut<BaseResultAPI<int>, int>(
                "Subjects/deletesubjects",
                Method.POST,
                null,
                new List<string[]> {
                    new[]{"id",id.ToString()}
                });
            return response != null ? response.RowEffect : 1;
        }
        public SubjectsModel GetSubjectsById(int id)
        {
            var response = GetDataFromApiOut<SubjectsModel>(
                "Subjects/getsubjectsbyid",
                Method.GET,
                null,
                new List<string[]> {
                    new[]{"id",id.ToString()}
                });
            return response;
        }
    }
}
