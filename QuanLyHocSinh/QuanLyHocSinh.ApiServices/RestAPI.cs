
using Newtonsoft.Json;
using QuanLyHocSinh.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinh.ApiServices
{
    [Obsolete]
    public class RestAPI
    {
        private RestClient _client;
        protected RestRequest request { get; set; }
        public Method Method { get; set; }

        public RestAPI(ApiConfig config)
        {
            _client = new RestClient(config.BaseUrl);
        }

        public T ExecuteResponse<T>(string resource,
            List<string[]> headers,
            List<string[]> queryStrings,
            ICredentials credentials,
            params Parameter[] arrParam) where T : new()
        {
            request = new RestRequest()
            {
                Resource = resource,
                Credentials = credentials,
                Method = this.Method
            };


            if (headers != null && headers.Count > 0)
            {
                // add header to request

                foreach (var header in headers)
                {
                    request.AddHeader(header[0], header[1]);
                }
            }

            if (queryStrings != null && queryStrings.Count > 0)
            {
                foreach (var queryString in queryStrings)
                {
                    request.AddQueryParameter(queryString[0], queryString[1]);
                }
            }

            if (arrParam != null && arrParam.Length > 0)
            {
                // add parameter to request
                foreach (var param in arrParam)
                {
                    request.AddParameter(param);
                }
            }

            //IRestResponse<T> response = _client.Execute<T>(request);
            IRestResponse response = _client.Execute(request);
            var content = response.Content; // raw content as string
                                            //if (typeof(T).Name.Contains("Tuple"))
                                            //{

            //}
            //return JsonConvert.DeserializeObject<T>(content);
            return JsonConvert.DeserializeObject<T>(content.Replace("m_Item", "Item"));
            //return response;
        }


        public async Task<T> ExecuteResponseAsyn<T>(string resource,
            List<string[]> headers,
            List<string[]> queryStrings,
            ICredentials credentials,
            params Parameter[] arrParam) where T : new()
        {
            request = new RestRequest()
            {
                Resource = resource,
                Credentials = credentials,
                Method = this.Method
            };


            if (headers != null && headers.Count > 0)
            {
                // add header to request

                foreach (var header in headers)
                {
                    request.AddHeader(header[0], header[1]);
                }
            }

            if (queryStrings != null && queryStrings.Count > 0)
            {
                foreach (var queryString in queryStrings)
                {
                    request.AddQueryParameter(queryString[0], queryString[1]);
                }
            }

            if (arrParam != null && arrParam.Length > 0)
            {
                // add parameter to request
                foreach (var param in arrParam)
                {
                    request.AddParameter(param);
                }
            }

            IRestResponse<T> response = await _client.ExecuteTaskAsync<T>(request);
            return response.Data;
        }


        public void AddParameter<T>(T obj, ref List<Parameter> parameters)
        {
            if (parameters == null)
                parameters = new List<Parameter>();

            string json = JsonConvert.SerializeObject(obj);

            Parameter param = new Parameter
            (
                "application/json; charset=utf-8",
                json,
                ParameterType.RequestBody
            );

            parameters.Add(param);
        }
    }
}
