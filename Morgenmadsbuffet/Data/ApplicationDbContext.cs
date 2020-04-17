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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BreakfastBookingsModel>()
                .HasKey(b => new {b.RoomId, b.Date });

            modelBuilder.Entity<CheckInsModel>()
                .HasOne<BreakfastBookingsModel>(c => c.BreakfastBookingsModels)
                .WithMany(b => b.CheckInsModelList)
                .HasForeignKey(c => new {c.RoomId, c.Date });
        }
    }
}

