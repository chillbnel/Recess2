using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LetsPlay.Models
{
    public class PlayerSignups
    {
        public string Username { get; set; }
        [ForeignKey("Posts")]
        public int PostID { get; set; }

        public Post Post { get; set; }
    }
}
