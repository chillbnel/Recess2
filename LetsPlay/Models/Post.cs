using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LetsPlay.Models
{
    public class Post
    {
        public int ID { get; set; } //Primary Key, auto - by DB
        public string Username { get; set; } //auto
        [Required]
        public string Title { get; set; }
        public DateTime PostedDate { get; set; } //auto
        [Required]
        [EnumDataType(typeof(EventType))]
        public EventType Type { get; set; } // dropdown
        [Required]
        [EnumDataType(typeof(Category))]
        public Category Category { get; set; } //dropdown
        [Required]
        public string Game { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public string Location { get; set; }

        public PlayerSignups Signups { get; set; }
        public Comments Comments { get; set; }
    }

    public enum EventType
    {
        Event,
        LFM
    }

    public enum Category
    {
        Sports,
        VideoGames,
        Tabletop,
        Misc
    }
}
