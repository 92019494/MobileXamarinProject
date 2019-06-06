using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SQLite;
using Xamarin.Forms;

namespace MobileProject
{
    public class TicketDataAccess
    {
        private SQLiteConnection database;
        private static object collisionLock = new object();

        public ObservableCollection<Ticket> Tickets { get; set; }

        public TicketDataAccess()
        {

            database = DependencyService.Get<IDatabaseConnection>().DbConnection();
            database.CreateTable<Ticket>();
            this.Tickets = new ObservableCollection<Ticket>(GetFilteredTickets());
            if (this.Tickets.Count < 1)
            {
                AddTestData();
                SaveTestData();
                //GetFilteredTickets();  database.Table<Ticket>()
            }
            

        }

        public void AddTestData()
        {
            this.Tickets.Add(new Ticket
            {
                Task = "Fruit Product Display",
                Started = false,
                Stopped = false,
                Completed = false,
                Background_color = "White",
                Current_status = "Not Started",
                Comment_entry = "",
                Comment = "",
                Time_taken_seconds = 0,
                Time_taken_minutes = 0,
                Time_taken_hours = 0
            });
            this.Tickets.Add(new Ticket
            {
                Task = "Makeup Product Display",
                Started = false,
                Stopped = false,
                Completed = false,
                Background_color = "White",
                Current_status = "Not Started",
                Comment_entry = "",
                Comment = "",
                Time_taken_seconds = 0,
                Time_taken_minutes = 0,
                Time_taken_hours = 0
            });
            this.Tickets.Add(new Ticket
            {
                Task = "Perfume Product Display",
                Started = false,
                Stopped = false,
                Completed = false,
                Background_color = "White",
                Current_status = "Not Started",
                Comment_entry = "",
                Comment = "",
                Time_taken_seconds = 0,
                Time_taken_minutes = 0,
                Time_taken_hours = 0
            });
            this.Tickets.Add(new Ticket
            {
                Task = "Lamps Product Display",
                Started = false,
                Stopped = false,
                Completed = false,
                Background_color = "White",
                Current_status = "Not Started",
                Comment_entry = "",
                Comment = "",
                Time_taken_seconds = 0,
                Time_taken_minutes = 0,
                Time_taken_hours = 0
            });
            this.Tickets.Add(new Ticket
            {
                Task = "Vegetable Product Display",
                Started = false,
                Stopped = false,
                Completed = false,
                Background_color = "White",
                Current_status = "Not Started",
                Comment_entry = "",
                Comment = "",
                Time_taken_seconds = 0,
                Time_taken_minutes = 0,
                Time_taken_hours = 0
            });
        }

        public void SaveTestData()
        {
            lock (collisionLock)
            {
                foreach (var ticketInstance in this.Tickets)
                {
                    if (ticketInstance.Ticket_id != 0)

                    {
                        database.Update(ticketInstance);
                    }
                    else
                    {
                        database.Insert(ticketInstance);
                    }
                }
            }
        }

        public void DeleteAllTickets()
        {
            lock (collisionLock)
            {
                database.DropTable<Ticket>();
                database.CreateTable<Ticket>();
            }
            this.Tickets = null;
            this.Tickets = new ObservableCollection<Ticket>(database.Table<Ticket>());
        }

        public void SaveAllTickets()
        {
            lock (collisionLock)
            {
                foreach (var ticketInstance in this.Tickets)
                {
                    if (ticketInstance.Ticket_id != 0)

                    {
                        database.Update(ticketInstance);
                    }
                    else
                    {
                        database.Insert(ticketInstance);
                        
                    }
                }
            }
        }
        

        public IEnumerable<Ticket> GetFilteredTickets()
        {
            lock (collisionLock)
            {
                
                return database.Query<Ticket>("SELECT * FROM Ticket ORDER BY Completed").AsEnumerable();
            }
        }





    }
}
