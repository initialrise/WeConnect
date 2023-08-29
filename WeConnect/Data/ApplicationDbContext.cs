﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using WeConnect.Models;

namespace WeConnect.Data
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        public DbSet<Posts> Posts { get; set; }
        public DbSet<Threads> Threads { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Threads>().HasData(
                new Threads { Id = 1, Name = "CSIT" },
                new Threads { Id = 2, Name = "BCA" },
                new Threads { Id = 3, Name = "BIM" }
                );
        }
    }
}
