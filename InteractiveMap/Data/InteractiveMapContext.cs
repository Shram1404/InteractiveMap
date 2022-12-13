using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InteractiveMap.Models;

namespace InteractiveMap.Data
{
    public class InteractiveMapContext : DbContext
    {
        public InteractiveMapContext (DbContextOptions<InteractiveMapContext> options)
            : base(options)
        {
        }

        public DbSet<InteractiveMap.Models.Audience> Audience { get; set; } = default!;
    }
}


