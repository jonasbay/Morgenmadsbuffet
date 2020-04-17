using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Morgenmadsbuffet.Models;

namespace Morgenmadsbuffet.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BreakfastBookingsModel> BreakfastBookings { get; set; }
        public DbSet<CheckInsModel> CheckIns { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<CheckInsModel>()
                .HasOne(c => c.BreakfastBookingsModels)
                .WithMany(b => b.CheckInsModelList)
                .HasForeignKey(c => c.CheckInsModelId);
        }
    }
}

