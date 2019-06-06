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
    public partial class SupervisorListView : ContentPage
    {
    
        ClientDataAccess dataAccess;

        public SupervisorListView()
        {

            InitializeComponent();
            dataAccess = new ClientDataAccess();
            this.BindingContext = dataAccess;

        }

        private async void MerchandisersButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SupervisorsMerchandisersListView());
        }

        private void AddClientButtonClicked(object sender, EventArgs e)
        {
            this.dataAccess.AddNewClient();
        }

        private async void DeleteAllClientsButtonClicked(object sender, EventArgs e)
        {
            if (this.dataAccess.Clients.Any())
            {
                var result = await DisplayAlert("Confirmation", "Are you sure you want to remove all clients?", "OK", "Cancel");
                if (result == true)
                {
                    this.dataAccess.DeleteAllClients();
                    this.BindingContext = this.dataAccess;
                }
            }
        }


        private void SaveAllClientsButtonClicked(object sender, EventArgs e)
        {
            this.dataAccess.SaveAllClients();
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
