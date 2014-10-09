using Axosoft.Core.Models;
using Newtonsoft.Json;
using PCLStorage;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Axosoft.Core.Services
{
    public class Auth
    {
        private const String CLIENT_ID =     "993863c6-7508-4d0d-ad86-7463872d5bdb";
        private const string CLIENT_SECRET = "08540b60-dac4-42fb-b010-6b357b74d067";    
        
        private static Auth _instance = new Auth();

        private Auth() { }

        public static Auth Instance {get {return _instance; }}

        private AuthSettings _settings = null;

        public async Task<AuthSettings> GetExisitngAsync()
        {
            if (_settings != null)
                return _settings;

            try
            {
                var fldr = FileSystem.Current.LocalStorage;
                var file = await fldr.GetFileAsync("authsettings.cfg");
                if (file != null)
                {
                    var authSettings = await file.ReadAllTextAsync();
                    _settings = JsonConvert.DeserializeObject<AuthSettings>(authSettings);
                    return _settings;
                }
                return null;
            }
            catch(Exception)
            {
                return null;
            }
      }

        
        public async Task<AuthSettings> GetTokenAsync(String site, String userName, String password)
        {
            try
            {
                var url = String.Format("https://{0}/api/oauth2/token?grant_type=password&username={1}&password={2}&client_id={3}&client_secret={4}&scope=read%20write", site, userName, password, CLIENT_ID, CLIENT_SECRET);
                var client = new HttpClient();
                Debug.WriteLine(url);
                var responseString = await client.GetStringAsync(url);
                var authResponse = JsonConvert.DeserializeObject<AuthSettings>(responseString);
                authResponse.URL = site;

                await Settings.Instance.SaveSettings(authResponse);

                return authResponse;
            }
            catch(Exception ex)
            {
                Debug.WriteLine("EXCEPTION PROCESSINGLOGIN: " + ex.Message);
                return null;
            }
        }
    }
}
