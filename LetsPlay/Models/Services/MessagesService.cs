using LetsPlay.Data;
using LetsPlay.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsPlay.Models.Services
{
    public class MessagesService : IMessages
    {
        private LetsPlayDbContext _context;

        public MessagesService(LetsPlayDbContext context)
        {
            _context = context;
        }

        public async Task CreateMessage(Messages message)
        {
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMessage(int id)
        {
            Messages message = await GetSingleMessage(id);
            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Messages>> GetAllMessages()
        {
            return await _context.Messages.ToListAsync();
        }

        public async Task<IEnumerable<Messages>> GetAllMessagesForUser(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<Messages> GetSingleMessage(int? id)
        {
            var result = await _context.Messages.FindAsync(id);
            return result;
        }
    }
}
