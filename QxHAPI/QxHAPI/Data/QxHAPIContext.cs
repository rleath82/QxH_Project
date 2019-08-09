using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace QxHAPI.Models
{
    public class QxHAPIContext : DbContext
    {
        public QxHAPIContext (DbContextOptions<QxHAPIContext> options)
            : base(options)
        {
        }

        public DbSet<QxHAPI.Models.Merchandise> Merchandise { get; set; }
    }
}
