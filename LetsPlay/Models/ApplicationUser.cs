using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LetsPlay.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Display(Name = "Name")]
        public string firstName { get; set; }

        [Required]
        [Display(Name = "Gamer Tag")]
        public string gamerTag { get; set; }

        [Required]
        [Display(Name = "Age")]
        public DateTime age { get; set; }

        [Required]
        [Display(Name = "Your Location")]
        public DateTime location { get; set; }
    }
}
