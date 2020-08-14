using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Nyhetssajt.Models
{
    public class NyhetspuffsContext : DbContext
    {
        public NyhetspuffsContext (DbContextOptions<NyhetspuffsContext> options)
            : base(options)
        {
        }

        public DbSet<Nyhetssajt.Models.Nyhetspuff> Nyhetspuff { get; set; }
    }
}
