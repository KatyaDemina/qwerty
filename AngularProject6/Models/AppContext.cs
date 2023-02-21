using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularProject6.Models
{
    public class AppContext : DbContext
    {public AppContext(DbContextOptions<AppContext>opts):
            base(opts)
        {
            Database.EnsureCreated();
        }
        public DbSet<Film> Films { get; set; }
    }
}
