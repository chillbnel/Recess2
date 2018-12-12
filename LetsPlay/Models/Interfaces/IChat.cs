using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsPlay.Models.Interfaces
{
    public interface IChat
    {
        Task<IEnumerable<GeneralChat>> GetMessages();

        Task CreateMessage(GeneralChat chat);
    }
}
