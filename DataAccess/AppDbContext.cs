using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class AppDbContext
    {
        public static List<Status> Statuses { get; set; }
        public static List<User> Users { get; set; }


        static AppDbContext()
        {
            Statuses = new List<Status>();
            Users = new List<User>();
        }
    }
}
