﻿using AspNetCoreMvcSample.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMvcSample.Models
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet< Teacher> Teachers { get; set; }
    }
}
