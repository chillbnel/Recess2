using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsPlay.Models.ViewModels
{
    public class SignupViewModel
    {
        public Post Post { get; set; }
        public IEnumerable<Comments> Comments { get; set; }
        public IEnumerable <PlayerSignups> SignUps{ get; set; }
    }
}
