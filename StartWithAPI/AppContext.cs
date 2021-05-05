using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartWithAPI
{
    public class AppContext : DbContext
    {
        public DbSet<AppUser> Users { get; set; }

        public AppContext(DbContextOptions options)
            : base(options)
        {

        }

    }
}
