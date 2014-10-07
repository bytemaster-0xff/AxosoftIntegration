using Axosoft.Core.Models;
using Cirrious.MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axosoft.Core.ViewModel
{
    public class MainViewModel : MvxViewModel
    {
        public ObservableCollection<Feature> WorkListItems { get; private set; }

        public async void Refresh()
        {
            var response = await Services.WorkItems.Instance.GetFeaturesAsync(0, 100);
            WorkListItems = response.Response;
            RaisePropertyChanged(() => WorkListItems);
        }

        public MvxCommand RefreshCommand { get { return new MvxCommand(() => Refresh()); } }
    }
}
