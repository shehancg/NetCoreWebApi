﻿using CoreWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagementSystem.API.Data
{
    public class SchoolManagementContext : DbContext
    {
        public SchoolManagementContext(DbContextOptions<SchoolManagementContext> options) : base(options)
        {
        }

        /*public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }*/
        public DbSet<ClassroomModel> Classrooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add any additional configurations here if needed
        }
    }
}
