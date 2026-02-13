using Microsoft.EntityFrameworkCore;
using VardSecAuth.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace VardSecAuth.Data
{
    public class AppDbContext : DbContext
    {
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

       
        public DbSet<User> Users { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
