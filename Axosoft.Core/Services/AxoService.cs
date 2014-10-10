using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Axosoft.Core.Services
{
    public class AxoServiceCallResponse<T> where T : class, new()
    {
        public T Response { get; set; }

        public bool Error { get; set; }
        public String ErroMessage { get; set; }
    }

    public class AxoService
    {
        private static AxoService _axoService = new AxoService();

        public static AxoService Instance { get { return _axoService; } }

        public async Task<AxoServiceCallResponse<T>> Call<T>(String path) where T : class, new()
        {
         
            var response = new AxoServiceCallResponse<T>();
            var client = new HttpClient();
                
            try
            {

                var requestedResource = String.Format("https://{0}/api/v4{1}", Settings.Instance.Auth.URL, path);
                Debug.WriteLine("RESOURCE -> " + requestedResource);
                var uri = new Uri(requestedResource);
                client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", Settings.Instance.Auth.AccessToken));
                Debug.WriteLine("Authorization: Bearer " + Settings.Instance.Auth.AccessToken);
                var httpResponse = await client.GetAsync(uri);
                if (httpResponse.IsSuccessStatusCode)
                {
                    var responseString = await httpResponse.Content.ReadAsStringAsync();
                    Debug.WriteLine(responseString);

                    response.Error = false;
                    response.Response = JsonConvert.DeserializeObject<T>(responseString);
                }
                else
                {
                    response.Error = true;
                    response.ErroMessage = httpResponse.ReasonPhrase;

                    Debug.WriteLine("======================================");
                    Debug.WriteLine("Exception making service call");
                    Debug.WriteLine("Return Code: " + httpResponse.StatusCode);
                    Debug.WriteLine(httpResponse.ReasonPhrase);
                    Debug.WriteLine("======================================");
                }

            }
            catch(Exception ex)
            {
                Debug.WriteLine("======================================");
                Debug.WriteLine("Exception making service call");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("======================================");

                response.Error = true;
                response.ErroMessage = ex.Message;    
            }

            return response;
            
        }
    }
}
