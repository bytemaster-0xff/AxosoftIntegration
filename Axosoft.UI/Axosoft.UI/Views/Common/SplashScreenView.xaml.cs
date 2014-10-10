using Axosoft.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using svc = Axosoft.Core.Services;

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

            await svc.Common.Instance.InitAsync();

            await svc.WorkItems.Instance.GetTasksAsync(0, 20);
           // await svc.WorkItems.Instance.GetFeaturesAsync(0, 20);

            await Projects.Instance.SyncAsync();
            await svc.Common.Instance.SyncAsync();

            await Projects.Instance.InitAsync();


            if (Settings.Instance.IsAuthenticated)
                await Navigation.PushModalAsync(new Common.LauncherView());
            else
                await Navigation.PushModalAsync(new Common.LoginView());
        }
    }
}
