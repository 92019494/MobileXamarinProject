using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SQLite;
using Xamarin.Forms;

namespace MobileProject
{
    public class ClientDataAccess
    {

        private SQLiteConnection database;
        private static object collisionLock = new object();

        public ObservableCollection<Client> Clients { get; set; }

        public ClientDataAccess()
        {
            database = DependencyService.Get<IDatabaseConnection>().DbConnection();
            database.CreateTable<Client>();
            this.Clients = new ObservableCollection<Client>(database.Table<Client>());
            if (this.Clients.Count < 1)
            {
                AddNewClient();
            }
        }

        public void AddNewClient()
        {
            this.Clients.Add(new Client
            {
                Name = "Enter client name here",
                Supervisor_id = 0
            });
        }

        public Client GetClient(int id)
        {
            lock (collisionLock)
            {
                return database.Table<Client>().FirstOrDefault(client => client.Client_id == id);
            }
        }

        public int SaveClient(Client clientInstance)
        {
            lock (collisionLock)
            {
                if (clientInstance.Client_id != 0)
                {
                    database.Update(clientInstance);
                    return clientInstance.Client_id;
                }
                else
                {
                    database.Insert(clientInstance);
                    return clientInstance.Client_id;
                }
            }
        }

        public void SaveAllClients()
        {
            lock (collisionLock)
            {
                foreach (var clientInstance in this.Clients)
                {
                    if (clientInstance.Client_id != 0)

                    {
                        database.Update(clientInstance);
                    }
                    else
                    {
                        database.Insert(clientInstance);
                    }
                }
            }
        }


        public int DeleteClient(Client clientInstance)
        {
            var id = clientInstance.Client_id;
            if (id != 0)
            {
                lock (collisionLock)
                {
                    database.Delete<Client>(id);
                }
            }
            this.Clients.Remove(clientInstance);
            return id;
        }


        public void DeleteAllClients()
        {
            lock (collisionLock)
            {
                database.DropTable<Client>();
                database.CreateTable<Client>();
            }
            this.Clients = null;
            this.Clients = new ObservableCollection<Client>(database.Table<Client>());
        }

    }
}