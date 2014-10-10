using Axosoft.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axosoft.UI.Views.WorkItems
{
    public partial class WorkItemView
    {
        public Feature Feature {get; set;}

        public WorkItemView()
        {
            InitializeComponent();

            TextItem.Text = "Hello World";
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

          

            BindingContext = Feature;
        }
    }
}
