using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LanchesMacApp.Models;

namespace LanchesMacApp.Data
{
    public class LanchesMacAppContext : DbContext
    {
        public LanchesMacAppContext (DbContextOptions<LanchesMacAppContext> options)
            : base(options)
        {
        }

        public DbSet<LanchesMacApp.Models.Lanche> Lanche { get; set; }
    }
}
