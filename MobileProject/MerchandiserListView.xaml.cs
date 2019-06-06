using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading;
using System.Text;


namespace MobileProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MerchandiserListView : ContentPage
    {

        TicketDataAccess dataAccess;
        Stopwatch timer = new Stopwatch();
        int currentID;
        bool timerStarted = false;

        public MerchandiserListView()
        {
            InitializeComponent();
            dataAccess = new TicketDataAccess();
            dataAccess.GetFilteredTickets();

            this.BindingContext = dataAccess.GetFilteredTickets();

            // deletes tickets - for testing purposes - only use to reset Ticket table data
            //dataAccess.DeleteAllTickets();

            foreach (Ticket item in dataAccess.Tickets)
            {
                if (item.Started)
                {
                    item.Current_status = "Stopped";
                    item.Started = false;
                    item.Stopped = true;
                }


                //if (item.Time_taken_seconds == 0
                //    && item.Time_taken_minutes == 0
                //    && item.Time_taken_hours == 0)
                //{
                //    item.Current_status = "Not Started";
                //}
            }
            CheckTicket();




            MyListView.ItemsSource = dataAccess.Tickets;
        }

        private async void StartTicketButtonClicked(object sender, EventArgs e)
        {
            CheckTicket();
            var currentTicket = this.MyListView.SelectedItem as Ticket;
            if (currentTicket != null)
            {
                if (!timerStarted)
                {
                    currentTicket.Started = true;
                    currentTicket.Stopped = false;
                    currentTicket.Completed = false;
                    currentTicket.Current_status = "In Progress";
                    //currentTicket.Background_color = "White";
                    dataAccess.SaveTestData();

                    timer.Start();
                    timerStarted = true;
                    currentID = currentTicket.Ticket_id;

                } else if (timerStarted && currentID != currentTicket.Ticket_id)
                {
                    var result = await DisplayAlert(
                    " Another Ticket Is Still Active", "Please stop or complete currently active ticket to start a new one", "OK", " ");

                }
            }
        }

        private void StopTicketButtonClicked(object sender, EventArgs e)
        {
            CheckTicket();
            var currentTicket = this.MyListView.SelectedItem as Ticket;
            if (currentTicket != null)
            {
                // formatting time values 
                if (timerStarted && currentID == currentTicket.Ticket_id)
                {
                    currentTicket.Started = false;
                    currentTicket.Stopped = true;
                    currentTicket.Completed = false;
                    currentTicket.Current_status = "Stopped";
                    //currentTicket.Background_color = "White";

                    timer.Stop();
                    FormatTime(currentTicket);
                    timer.Reset();
                    //timer.Restart();

                    timerStarted = false;
                }
                dataAccess.SaveTestData();

            }
        }

        private void CompleteTicketButtonClicked(object sender, EventArgs e)
        {
            CheckTicket();
            var currentTicket = this.MyListView.SelectedItem as Ticket;
            if (currentTicket != null)
            {
                // formatting time values 
                if (timerStarted && currentID == currentTicket.Ticket_id || currentTicket.Stopped)
                {
                    currentTicket.Started = false;
                    currentTicket.Stopped = false;
                    currentTicket.Completed = true;
                    currentTicket.Current_status = "Completed";
                    dataAccess.Tickets.Remove(currentTicket);
                    dataAccess.Tickets.Add(currentTicket);
                    // currentTicket.Background_color = "Gray";

                    timer.Stop();
                    FormatTime(currentTicket);
                    timer.Reset();

                    //timer.Restart();

                    timerStarted = false;
                    currentTicket.Background_color = "Gray";
                }
                dataAccess.SaveTestData();
            }



        }

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            CheckTicket();
            var currentTicket = this.MyListView.SelectedItem as Ticket;
            if (currentTicket != null)
            {

                currentTicket.Background_color = "Gold";

            }
        }

        private void AddCommentButtonClicked(object sender, EventArgs e)
        {
            CheckTicket();
            var currentTicket = this.MyListView.SelectedItem as Ticket;
            if (currentTicket != null)
            {
                currentTicket.Comment += " " + currentTicket.Comment_entry + ".";
                currentTicket.Comment_entry = "";
                dataAccess.SaveTestData();

            }
        }

        private async void DeleteCommentButtonClicked(object sender, EventArgs e)
        {
            CheckTicket();
            var currentTicket = this.MyListView.SelectedItem as Ticket;
            if (currentTicket != null)
            {
                var result = await DisplayAlert("Conf" +
                    "irmation", "Are you sure you want to delete comments?", "OK", "Cancel");
                if (result == true)
                {
                    currentTicket.Comment = "";
                    dataAccess.SaveTestData();
                }


            }
        }

      

        // Formats time values
        private void FormatTime(Ticket currentTicket)
        {
            currentTicket.Time_taken_seconds += (int)timer.ElapsedMilliseconds % 60000 / 1000;
            int leftoverMinutes = 0;
            int leftoverHours = 0;
            while (currentTicket.Time_taken_seconds >= 60)
            {
                currentTicket.Time_taken_seconds -= 60;
                leftoverMinutes += 1;
            }
            currentTicket.Time_taken_minutes += leftoverMinutes;
            currentTicket.Time_taken_seconds %= 60;

            while (currentTicket.Time_taken_minutes > 60)
            {
                currentTicket.Time_taken_minutes -= 60;
                leftoverHours += 1;
            }
            currentTicket.Time_taken_hours += leftoverHours;
            currentTicket.Time_taken_minutes %= 60;
        }

        // Makes sure ticket properties are correct
        private void CheckTicket()
        {
            foreach (Ticket item in dataAccess.Tickets)
            {
            //if (!item.Completed && item.Current_status != "Not Started")
                //{
                //    item.Current_status = "Stopped";
                //    item.Started = false;
                //    item.Stopped = true;
                //}

                if (item.Started)
                {
                    item.Current_status = "In Progress";
                }
                else if (item.Stopped)
                {
                    item.Current_status = "Stopped";
                }
                else if (item.Completed)
                {
                    item.Current_status = "Completed";
                }
                else
                {
                    item.Current_status = "Not Started";
                }

                if (item.Current_status == "Completed")
                {
                    item.Background_color = "Gray";
                }
                else
                {
                    item.Background_color = "White";
                }


                var currentTicket = this.MyListView.SelectedItem as Ticket;
                if (currentTicket != null)
                {
                    currentTicket.Background_color = "Gold";
                }

            }
        }

       
    }
}
