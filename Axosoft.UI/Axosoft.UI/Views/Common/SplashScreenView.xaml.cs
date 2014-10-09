using Axosoft.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axosoft.UI.Views.Common
{
    public partial class SplashScreenView
    {
        public SplashScreenView()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await Settings.Instance.Init();

            if (Settings.Instance.IsAuthenticated)
                await Navigation.PushModalAsync(new Common.LauncherView());
            else
                await Navigation.PushModalAsync(new Common.LoginView());
        }
    }
}
