using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
//using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using QuanLyHocSinh.DTO;
using QuanLyHocSinh.Utilities;

namespace QuanLyHocSinh.DAL.Dapper
{
    public class Dapper : IDisposable
    {
        private readonly IConfiguration _config;
        private string Connectionstring = "DBConnection";

        public Dapper(IConfiguration config)
        {
            _config = config;
        }

        public void Dispose()
        {
        }

        public DbConnection GetDbconnection()
        {
            return new SqlConnection(_config.GetConnectionString(Connectionstring));
        }

        public void Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            var db = GetDbconnection();
            db.Execute(sp, parms, commandType: commandType);
        }

        public List<OutputModel> ExecuteNonQueryWithOutObject(string spname, params object[] parameters)
        {
            List<OutputModel> model = new List<OutputModel>();
            try
            {
                var query = spname;
                var param = new DynamicParameters();
                for (int i = 0; i < parameters.Length - 1; i += 2)
                {
                    if (CommonLib.IsNullString(parameters[i]).Contains("|out"))
                    {
                        param.Add(CommonLib.IsNullString(parameters[i]).Replace("|out", ""), parameters[i + 1], direction: ParameterDirection.Output);
                        OutputModel item = new OutputModel
                        {
                            Label = CommonLib.IsNullString(parameters[i]).Replace("|out", ""),
                            Value = ""
                        };
                        model.Add(item);
                    }
                    else
                    {
                        param.Add(parameters[i].ToString(), parameters[i + 1]);
                    }
                }
                var context = new SqlConnection(_config.GetConnectionString(Connectionstring));
                context.Execute(query, param, commandType: System.Data.CommandType.StoredProcedure);
                for (int i = 0; i < model.Count; i++)
                {
                    model[i].Value = CommonLib.IsNullString(param.Get<dynamic>(model[i].Label));
                }

            }
            catch (Exception ex)
            {
               
            }
            return model;
        }

        protected List<T> ExcuteSprocWithParamTable<T>(string spname, params object[] parameters)
        {

            var query = spname;
            var param = new DynamicParameters();
            for (int i = 0; i < parameters.Length - 1; i += 2)
            {
                if (CommonLib.IsNullString(parameters[i]).Contains("|table"))
                {
                    var listParam = parameters[i].ToString().Split('|');
                    param.Add(listParam[0].ToString(), ((DataTable)parameters[i + 1]).AsTableValuedParameter(listParam[2].ToString()));
                }
                else if (CommonLib.IsNullString(parameters[i]).Contains("|out"))
                {
                    param.Add(CommonLib.IsNullString(parameters[i]).Replace("|out", ""), parameters[i + 1], direction: ParameterDirection.Output);
                }
                else
                {
                    param.Add(parameters[i].ToString(), parameters[i + 1]);
                }
            }
            var context = new SqlConnection(_config.GetConnectionString(Connectionstring));
            return context.Query<T>(query, param, commandType: System.Data.CommandType.StoredProcedure).ToList();

        }

        protected void ExcuteSprocWithParamTable(string spname, string dbConnect, params object[] parameters)
        {
            var query = spname;
            var param = new DynamicParameters();
            for (int i = 0; i < parameters.Length - 1; i += 2)
            {
                if (CommonLib.IsNullString(parameters[i]).Contains("|table"))
                {
                    var listParam = parameters[i].ToString().Split('|');
                    param.Add(listParam[0].ToString(), ((DataTable)parameters[i + 1]).AsTableValuedParameter(listParam[2].ToString()));
                }
                else if (CommonLib.IsNullString(parameters[i]).Contains("|out"))
                {
                    param.Add(CommonLib.IsNullString(parameters[i]).Replace("|out", ""), parameters[i + 1], direction: ParameterDirection.Output);
                }
                else
                {
                    param.Add(parameters[i].ToString(), parameters[i + 1]);
                }
            }
            var context = new SqlConnection(_config.GetConnectionString(Connectionstring));
            context.Query(query, param, commandType: System.Data.CommandType.StoredProcedure).ToList();

        }

        public T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            var db = GetDbconnection();
            return db.Query<T>(sp, parms, commandType: commandType).FirstOrDefault();
        }

        public List<T> GetList<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            var db = GetDbconnection();
            return db.Query<T>(sp, parms, commandType: commandType).ToList();
        }

        public T InsertOrUpdate<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;
            using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));

            if (db.State == ConnectionState.Closed)
                db.Open();

            try
            {
                result = db.Query<T>(sp, parms, commandType: commandType).FirstOrDefault();
            }
            catch (Exception ex)
            {
                result = db.Query<T>(null, null, null).FirstOrDefault();
                return result;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();

            }

            return result;
        }
    }
}
