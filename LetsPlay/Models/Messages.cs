using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsPlay.Models
{
    public class Messages
    {
        public int ID { get; set; }
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public bool Read { get; set; }
    }
}
