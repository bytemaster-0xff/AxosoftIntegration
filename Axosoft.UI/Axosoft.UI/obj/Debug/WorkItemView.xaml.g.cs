//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Axosoft.UI.Views.WorkItems {
    using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    
    
    public partial class WorkItemView : ContentPage {
        
        private Entry TextItem1;
        
        private Editor TextItem;
        
        private void InitializeComponent() {
            this.LoadFromXaml(typeof(WorkItemView));
            TextItem1 = this.FindByName<Entry>("TextItem1");
            TextItem = this.FindByName<Editor>("TextItem");
        }
    }
}
