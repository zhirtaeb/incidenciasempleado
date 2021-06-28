using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace IncidenciasEmpleados.Helpers
{
    public static class HttpClientHelper
    {

        public static async Task<T> GetAsync<T>(string baseUrl, string apiUrl, string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync(apiUrl + id);

                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsAsync<T>();
                    return EmpResponse.Result;
                }
                return default;
            }
        }

        public static async Task<List<T>> GetAllAsync<T>(string baseUrl, string apiUrl,int? id =null)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync(apiUrl + (id.HasValue ? id.Value.ToString() : ""));

                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsAsync<List<T>>();
                    return EmpResponse.Result;
                }
                return default;
            }
        }

      
    }
}