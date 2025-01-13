using ECommercePro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercePro.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // TODO: Add DbSets here.
        public DbSet<Product> Products { get; set; }
        //public DbSet<Order> Orders { get; set; }

        // onModelCreating, onConfiguring, etc.
    }
}
