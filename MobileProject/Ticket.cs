using System.Linq;
using SQLite;
using System.ComponentModel;


namespace MobileProject
{
    public class Ticket : INotifyPropertyChanged
    {

        private int ticket_id;
       
        [PrimaryKey, AutoIncrement]
        public int Ticket_id {
            get
            {
                return ticket_id;
            }
            set
            {
                this.ticket_id = value;
                OnPropertyChanged(nameof(Ticket_id));
            }
        }

        private string task;

        public string Task
        {
            get
            {
                return task;
            }
            set
            {
                this.task = value;
                OnPropertyChanged(nameof(Task));

            }
        }

        private bool started;

        public bool Started {
            get
            {
                return started;
            }
            set
            {
                this.started = value;
                OnPropertyChanged(nameof(Started));
            }
        }

        private bool stopped;

        public bool Stopped
        {
            get
            {
                return stopped;
            }
            set
            {
                this.stopped = value;
                OnPropertyChanged(nameof(Stopped));
            }
        }



        private bool completed;

        public bool Completed
        {
            get
            {
                return completed;
            }
            set
            {
                this.completed = value;
                OnPropertyChanged(nameof(Completed));

            }
        }

        private string background_color;

        public string Background_color
        {
            get
            {
                return background_color;
            }
            set
            {
                this.background_color = value;
                OnPropertyChanged(nameof(Background_color));

            }
        }

        private string current_status;
        public string Current_status
        {
            get
            {
                return current_status;
            }
            set
            {
                this.current_status = value;
                OnPropertyChanged(nameof(Current_status));
            }
        }

        private string comment_entry;
        public string Comment_entry
        {
            get
            {
                return comment_entry;
            }
            set
            {
                this.comment_entry = value;
                OnPropertyChanged(nameof(Comment_entry));
            }
        }

        private string comment;
        public string Comment
        {
            get
            {
                return comment;
            }
            set
            {
                this.comment = value;
                OnPropertyChanged(nameof(Comment));
            }
        }

        private int time_taken_seconds;
        public int Time_taken_seconds
        {
            get
            {
                return time_taken_seconds;
            }
            set
            {
                this.time_taken_seconds = value;
                OnPropertyChanged(nameof(Time_taken_seconds));
            }
        }

        private int time_taken_minutes;
        public int Time_taken_minutes
        {
            get
            {
                return time_taken_minutes;
            }
            set
            {
                this.time_taken_minutes = value;
                OnPropertyChanged(nameof(Time_taken_minutes));
            }
        }

        private int time_taken_hours;
        public int Time_taken_hours
        {
            get
            {
                return time_taken_hours;
            }
            set
            {
                this.time_taken_hours = value;
                OnPropertyChanged(nameof(Time_taken_hours));
            }
        }

        private string merchandiser_id;
        public string Merchandiser_id
        {
            get
            {
                return merchandiser_id;
            }
            set
            {
                this.current_status = value;
                OnPropertyChanged(nameof(Merchandiser_id));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
