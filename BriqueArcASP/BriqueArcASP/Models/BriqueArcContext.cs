using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BriqueArcASP.Models
{
    public class BriqueArcContext : DbContext
    {
        public BriqueArcContext(DbContextOptions<BriqueArcContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Ranking> Rankings { get; set; }

    }
}
