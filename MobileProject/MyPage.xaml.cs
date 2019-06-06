using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MobileProject
{
    public partial class MyPage : ContentPage
    {
        public MyPage()
        {
            InitializeComponent();
        }

        private async void MerchandiserButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MerchandiserListView());

        }

        private async void SupervisorButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SupervisorListView());

        }
    }
}
