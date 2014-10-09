using Axosoft.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axosoft.UI.Views.Common
{
    public partial class LoginView
    {
        public LoginView()
        {
            InitializeComponent();

            var vm = new LoginViewModel();

            BindingContext = vm;

            vm.LoginSuccess += vm_LoginSuccess;
        }

        void vm_LoginSuccess(object sender, EventArgs e)
        {
            this.Navigation.PushModalAsync(new Common.LauncherView());            
        }
    }
}
