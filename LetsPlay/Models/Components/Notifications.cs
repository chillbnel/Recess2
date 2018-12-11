using LetsPlay.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsPlay.Models.Components
{
    public class Notifications : ViewComponent
    {
        private IMessages _messages;

        public Notifications(IMessages messages)
        {
            _messages = messages;
        }


    }
}
