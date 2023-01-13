using Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class User: IEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public List<Status> Statuses { get; set; }

        public User user { get; set; }

        public User(string username)
        {
            Statuses = new List<Status>();
            Username = username;
        }
    }
}
