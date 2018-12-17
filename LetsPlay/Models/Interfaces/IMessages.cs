using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsPlay.Models.Interfaces
{
    public interface IMessages
    {
        Task<IEnumerable<Messages>> GetAllMessages();

        Task<Messages> GetSingleMessage(int? id);

        Task<IEnumerable<Messages>> GetAllMessagesForUser(string username);

        Task CreateMessage(Messages message);

        Task DeleteMessage(int id);
    }
}
