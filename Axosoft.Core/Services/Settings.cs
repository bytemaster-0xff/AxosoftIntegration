using Newtonsoft.Json;
using PCLStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axosoft.Core.Services
{
    public class Settings
    {
        private static Settings _instance = new Settings();
        private AuthSettings _auth;
        private const string CONFIG_SETTINGS = "config.cfg";

        public async Task Init()
        {
            var fldr = FileSystem.Current.LocalStorage;
            if((await fldr.CheckExistsAsync(CONFIG_SETTINGS)) == ExistenceCheckResult.FileExists)
            {
                var file = await fldr.GetFileAsync(CONFIG_SETTINGS);
                if (file != null)
                {
                    var authSettings = await file.ReadAllTextAsync();
                    _auth = JsonConvert.DeserializeObject<AuthSettings>(authSettings);
                }
                else
                    _auth = null;
            }
        }

        public async Task SaveSettings(AuthSettings authResponse)
        {
            var fldr = FileSystem.Current.LocalStorage;
            var file = await fldr.CreateFileAsync(CONFIG_SETTINGS, CreationCollisionOption.ReplaceExisting);
            await file.WriteAllTextAsync(JsonConvert.SerializeObject(authResponse));
        }

        public static Settings Instance
        {
            get
            {        
                return _instance; 
            }
        }

        public bool IsAuthenticated { get { return _auth != null; } }


        public AuthSettings Auth { get { return _auth; } }
    }
}
