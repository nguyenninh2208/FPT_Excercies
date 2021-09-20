using Microsoft.Extensions.Configuration;
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
    public class BaseServices
    {
        public ApiConfig pConfig { get; set; }
        public string token = "";

        protected T GetDataFromApiOut<T, TParam>(
            string resources,
            Method methodApi = Method.POST,
            List<string[]> headers = null,
            List<string[]> queryStrings = null,
            params TParam[] arrParam) where T : new()
        {
            RestAPI api = new RestAPI(pConfig);
            api.Method = methodApi;

            List<Parameter> parameters = null;

            if (arrParam != null && arrParam.Length > 0)
            {
                // add list param to rest api
                foreach (TParam param in arrParam)
                {
                    api.AddParameter<TParam>(param, ref parameters);
                }
            }
            if (headers == null)
            {
                headers = new List<string[]>();
            }
            headers.Add(new[] { "token", token });

            //headers.Add(new[] { "UserName", pConfig.UserName });
            //headers.Add(new[] { "Password", pConfig.Password });

            return api.ExecuteResponse<T>(resources, headers, queryStrings, null, (parameters != null ? parameters.ToArray() : null));
        }

        protected T GetDataFromApiOut<T>(
            string resources,
            Method methodApi = Method.POST,
            List<string[]> headers = null,
            List<string[]> queryStrings = null) where T : new()
        {
            RestAPI api = new RestAPI(pConfig);
            api.Method = methodApi;

            if (headers == null)
            {
                headers = new List<string[]>();
            }
            headers.Add(new[] { "token", token });
            //headers.Add(new[] { "UserName", pConfig.UserName });
            //headers.Add(new[] { "Password", pConfig.Password });

            return api.ExecuteResponse<T>(resources, headers, queryStrings, null, null);
        }
    }
}
