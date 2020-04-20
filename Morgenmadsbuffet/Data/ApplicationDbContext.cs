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

            //modelBuilder.Entity<CheckInsModel>()
            //    .HasOne(c => c.BreakfastBookingsModels)
            //    .WithMany(b => b.CheckInsModelList)
            //    .HasForeignKey(c => c.BreakfastBookingsModelId); // <<- Lavet denne om til RoomID i stedet for CheckInsModelsId

            modelBuilder.Entity<BreakfastBookingsModel>().HasData(
                new BreakfastBookingsModel { BreakfastBookingsModelId = 1, RoomId = 1, AdultCount = 1, ChildCount = 1, Date = "01-01-2020" },
                new BreakfastBookingsModel { BreakfastBookingsModelId = 2, RoomId = 2, AdultCount = 2, ChildCount = 2, Date = "01-01-2020" },
                new BreakfastBookingsModel { BreakfastBookingsModelId = 3, RoomId = 3, AdultCount = 2, ChildCount = 2, Date = "01-01-2020" },
                new BreakfastBookingsModel { BreakfastBookingsModelId = 4, RoomId = 4, AdultCount = 2, ChildCount = 2, Date = "02-01-2020" }
            );

            modelBuilder.Entity<CheckInsModel>().HasData(
                new CheckInsModel { CheckInsModelId = 1, RoomId = 1, AdultCount = 1, ChildCount = 0, Date = "01-01-2020" },
                new CheckInsModel { CheckInsModelId = 2, RoomId = 1, AdultCount = 0, ChildCount = 1, Date = "01-01-2020" },
                new CheckInsModel { CheckInsModelId = 3, RoomId = 2, AdultCount = 2, ChildCount = 2, Date = "01-01-2020" },
                new CheckInsModel { CheckInsModelId = 4, RoomId = 4, AdultCount = 2, ChildCount = 2, Date = "02-01-2020" }
            );
        }
    }
}

