using System.ComponentModel;
using SQLite;

namespace MobileProject
{
    public class Client : INotifyPropertyChanged
    {
        private int client_id;
        [PrimaryKey, AutoIncrement]

        public int Client_id
        {
            get
            {
                return client_id;
            }
            set
            {
                this.client_id = value;
                OnPropertyChanged(nameof(Client_id));
            }
        }

        private string name;
        [NotNull]

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                this.name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private int supervisor_id;

        public int Supervisor_id
        {
            get
            {
                return supervisor_id;
            }
            set
            {
                this.supervisor_id = value;
                OnPropertyChanged(nameof(Supervisor_id));
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
