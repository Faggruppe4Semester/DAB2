﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DAB_Assignment2.Models;

namespace DAB_Assignment2.Models
{
    public partial class Assignment2Context : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<HelpRequest> HelpRequests { get; set; }

        public Assignment2Context()
        {
        }

        public Assignment2Context(DbContextOptions<Assignment2Context> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Assignment2;User ID=SA;Password=Password1234!;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);

            modelBuilder.Entity<Exercise>().HasKey(e => new { e.Lecture, e.Number });
            modelBuilder.Entity<Exercise>().HasOne(e => e.Student)
                .WithMany(s => s.Exercises)
                .HasForeignKey(e => e.StudentAUID);

            modelBuilder.Entity<StudentCourse>().HasKey(sc => new { sc.StudentAUID, sc.CourseID });

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentAUID);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseID);

            modelBuilder.Entity<HelpRequest>().HasKey(sa => new { sa.StudentAUID, sa.AssignmentID });

            modelBuilder.Entity<HelpRequest>()
                .HasOne(sa => sa.Student)
                .WithMany(s => s.HelpRequests)
                .HasForeignKey(sa => sa.StudentAUID);

            modelBuilder.Entity<HelpRequest>()
                .HasOne(sa => sa.Assignment)
                .WithMany(a => a.HelpRequests)
                .HasForeignKey(sa => sa.AssignmentID);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
