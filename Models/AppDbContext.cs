using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace BizTrack.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Budget> Budget { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Expenses> Expenses { get; set; }
        public DbSet<Income> Income { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
    }
}
