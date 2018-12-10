using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsPlay.Models
{
    public class PlayerSignups
    {
        public string Username { get; set; }
        public int PostID { get; set; }

        public Post Post { get; set; }
    }
}
