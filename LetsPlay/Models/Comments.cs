using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsPlay.Models
{
    public class Comments
    {
        public int ID { get; set; } // primary key
        public string Username { get; set; } // ID DB
        public int PostID { get; set; } //foreign key
        public DateTime Date { get; set; }
        public string Message { get; set; }

        public Post Post { get; set; }
    }
}
