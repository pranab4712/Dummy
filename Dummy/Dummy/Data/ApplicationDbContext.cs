﻿using Dummy.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Dummy.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {


        }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<WalkDifficulty> WalkDifficulty{ get; set; }
    }
}
