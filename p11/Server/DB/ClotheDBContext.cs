using Microsoft.EntityFrameworkCore;
using P11.Server.Controllers;
using P11.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P11.Server.DB
{
    public class ClotheDBContext : DbContext
    {
        public ClotheDBContext(DbContextOptions<ClotheDBContext> options)
            : base(options)
        {}
        public DbSet<kala> Clothes {get; set;}
        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}