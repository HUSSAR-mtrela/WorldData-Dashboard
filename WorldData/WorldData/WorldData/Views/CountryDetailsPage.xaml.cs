﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace WorldData.Views
{
    public partial class CountryDetailsPage : ContentPage
    {
        public CountryDetailsPage()
        {
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync(true);
        }
    }
}
