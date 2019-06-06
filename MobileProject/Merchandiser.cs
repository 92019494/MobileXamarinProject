using System.Linq;
using SQLite;

namespace MobileProject
{
    public class Merchandiser
    {
        [PrimaryKey, AutoIncrement]
        public int merchandiser_id { get; set; }

        public string name { get; set; }

        public string phone_number { get; set; }

        public string email { get; set; }

        public int supervisor_id { get; set; }
    }
}
