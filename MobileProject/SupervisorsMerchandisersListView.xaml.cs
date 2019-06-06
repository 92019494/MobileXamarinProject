using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SupervisorsMerchandisersListView : ContentPage
    {
        public ObservableCollection<Merchandiser> Items { get; set; }

        public SupervisorsMerchandisersListView()
        {
            InitializeComponent();

            Merchandiser merch1 = new Merchandiser()
            {
                name = "April Ltd",
                phone_number = "0279738738",
                email = "merch1@mail.com",
                supervisor_id = 1
            };
            Merchandiser merch2 = new Merchandiser()
            {
                name = "Allied Int",
                phone_number = "0279738738",
                email = "merch2@mail.com",
                supervisor_id = 1
            };
            Merchandiser merch3 = new Merchandiser()
            {
                name = "CheapDealz",
                phone_number = "0279950738",
                email = "merch3@mail.com",
                supervisor_id = 1
            };
            Merchandiser merch4 = new Merchandiser()
            {
                name = "Save Rave",
                phone_number = "0279738738",
                email = "merch4@mail.com",
                supervisor_id = 1
            };
            Merchandiser merch5 = new Merchandiser()
            {
                name = "Super Saver",
                phone_number = "0279675873",
                email = "merch5@mail.com",
                supervisor_id = 1
            };
            Items = new ObservableCollection<Merchandiser>
            {
                merch1,
                merch2,
                merch3,
                merch4,
                merch5

            };

            MyListView.ItemsSource = Items;
        }



        private async void ClientsButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        //async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        //{
        //    if (e.Item == null)
        //        return;

        //    await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

        //    //Deselect Item
        //    ((ListView)sender).SelectedItem = null;
        //}
    }
}
