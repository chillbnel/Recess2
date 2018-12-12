using LetsPlay.Data;
using LetsPlay.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsPlay.Models.Services
{
    public class ChatService : IChat
    {
        private LetsPlayDbContext _context;

        public ChatService(LetsPlayDbContext context)
        {
            _context = context;
        }

        public async Task CreateMessage(GeneralChat chat)
        {
            _context.GeneralChats.Add(chat);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GeneralChat>> GetMessages()
        {
            return await _context.GeneralChats.ToListAsync();
        }
    }
}
