using Axosoft.Core.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axosoft.UI.Views.WorkItems
{
    public partial class WorkListView
    {
        public WorkListView()
        {
            InitializeComponent();
        }

        void MyWorkList_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var view = new WorkItemView();
            view.Feature = e.SelectedItem as Feature;
            Navigation.PushModalAsync(view);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                WaitIndicator.IsRunning = true; 
                MyWorkList.ItemsSource = (await Axosoft.Core.Services.WorkItems.Instance.GetFeaturesAsync(0, 20)).Response.Features;
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Error binding Exceptions");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }
            finally
            {
                WaitIndicator.IsRunning = false;
            }
        }
    }
}
