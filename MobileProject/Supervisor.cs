using System.Linq;
using SQLite;

namespace MobileProject
{
    public class Supervisor
    {
        [PrimaryKey, AutoIncrement]
        public int supervisor_id { get; set; }
    }
}
