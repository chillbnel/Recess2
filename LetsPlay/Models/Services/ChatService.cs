using LetsPlay.Data;
using LetsPlay.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsPlay.Models.Services
{
    public class ChatService : IChat
    {
        private LetsPlayDbContext _context;
        public Task<IEnumerable<GeneralChat>> GetMessages()
        {
            
        }
    }
}
