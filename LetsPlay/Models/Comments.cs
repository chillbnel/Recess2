using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LetsPlay.Models
{
    public class Comments
    {
        [Key]
        public int ID { get; set; } // primary key
        public string Username { get; set; } // ID DB

        public int PostNumber { get; set; } //foreign key
        public string Message { get; set; }

    }
}
