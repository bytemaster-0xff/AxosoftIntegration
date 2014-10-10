﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axosoft.UI.Views.Common
{
    public partial class LauncherView
    {
        public LauncherView()
        {
            InitializeComponent();
        }

        public void MyWork_Clicked(Object snd, EventArgs args)
        {
            Navigation.PushModalAsync(new Views.WorkItems.WorkListView());
        }
    }
}
