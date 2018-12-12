using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsPlay.Models.Interfaces
{
    interface IChat
    {
        Task<IEnumerable<GeneralChat>> GetMessages();
    }
}
