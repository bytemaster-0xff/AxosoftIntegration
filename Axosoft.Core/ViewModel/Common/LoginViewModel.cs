using Axosoft.Core.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axosoft.Core.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        public event EventHandler LoginSuccess;

        public String EmailAddress { get; set; }
        public String Password { get; set; }

        public async void Login()
        {
            var result = await Auth.Instance.GetTokenAsync("mintek.axosoft.com", EmailAddress, Password);
            if (result != null)
            {
                Debug.WriteLine(result.User.Email);
                LoginSuccess(this, null);
            }
            else
                Debug.WriteLine("ERROR AUTHENTICATING");
        }

        public RelayCommand LoginCommand { get { return new RelayCommand(() => Login()); } }    
    }
}
