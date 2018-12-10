using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsPlay.Data
{
    public class LetsPlayDbContext : DbContext
    {
        public LetsPlayDbContext(DbContextOptions<LetsPlayDbContext> options) : base(options)
        {
        }

    }
}
