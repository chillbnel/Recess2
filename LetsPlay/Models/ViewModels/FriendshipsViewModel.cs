using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsPlay.Models.ViewModels
{
    public class FriendshipsViewModel
    {
        public ApplicationUser User { get; set; }
        public IEnumerable<ApplicationUser> ViewUserFriends { get; set; }
        public IEnumerable<ApplicationUser> Friends { get; set; }
        public IEnumerable<ApplicationUser> SentRequests { get; set; }
        public IEnumerable<ApplicationUser> ReceivedRequests { get; set; }
    }
}
