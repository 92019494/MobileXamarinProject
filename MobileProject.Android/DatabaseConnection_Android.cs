using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SQLite;
using MobileProject.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnection_Android))]
namespace MobileProject.Droid
{
    public class DatabaseConnection_Android : IDatabaseConnection
    {
        public SQLiteConnection DbConnection()
        {
            var dbName = "MobileDevelopmentProject.sqlite";
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dbName);
            return new SQLiteConnection(path);
        }

    
    }
}
