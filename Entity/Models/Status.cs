using Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Status:IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime SharedDate { get; set; }
        public User User { get; set; }

        public Status(string title, string content)
        {
            SharedDate = DateTime.Now;
            Title = title;
            Content = content;
        }
    }
}
