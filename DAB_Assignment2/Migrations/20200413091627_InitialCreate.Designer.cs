﻿// <auto-generated />
using DAB_Assignment2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAB_Assignment2.Migrations
{
    [DbContext(typeof(Assignment2Context))]
    [Migration("20200413091627_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAB_Assignment2.Models.Assignment", b =>
                {
                    b.Property<int>("AssignmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<string>("TeacherAUID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AssignmentID");

                    b.HasIndex("CourseID");

                    b.HasIndex("TeacherAUID");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("DAB_Assignment2.Models.Course", b =>
                {
                    b.Property<int>("CourseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseID");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("DAB_Assignment2.Models.Exercise", b =>
                {
                    b.Property<string>("Lecture")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<string>("Help_Where")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Open")
                        .HasColumnType("bit");

                    b.Property<string>("StudentAUID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TeacherAUID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Lecture", "Number");

                    b.HasIndex("CourseID");

                    b.HasIndex("StudentAUID");

                    b.HasIndex("TeacherAUID");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("DAB_Assignment2.Models.Student", b =>
                {
                    b.Property<string>("AUID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AUID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("DAB_Assignment2.Models.HelpRequest", b =>
                {
                    b.Property<string>("StudentAUID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AssignmentID")
                        .HasColumnType("int");

                    b.HasKey("StudentAUID", "AssignmentID");

                    b.HasIndex("AssignmentID");

                    b.ToTable("HelpRequests");
                });

            modelBuilder.Entity("DAB_Assignment2.Models.StudentCourse", b =>
                {
                    b.Property<string>("StudentAUID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("Semester")
                        .HasColumnType("int");

                    b.HasKey("StudentAUID", "CourseID");

                    b.HasIndex("CourseID");

                    b.ToTable("StudentCourses");
                });

            modelBuilder.Entity("DAB_Assignment2.Models.Teacher", b =>
                {
                    b.Property<string>("AUID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AUID");

                    b.HasIndex("CourseID");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("DAB_Assignment2.Models.Assignment", b =>
                {
                    b.HasOne("DAB_Assignment2.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAB_Assignment2.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherAUID");
                });

            modelBuilder.Entity("DAB_Assignment2.Models.Exercise", b =>
                {
                    b.HasOne("DAB_Assignment2.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAB_Assignment2.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentAUID");

                    b.HasOne("DAB_Assignment2.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherAUID");
                });

            modelBuilder.Entity("DAB_Assignment2.Models.HelpRequest", b =>
                {
                    b.HasOne("DAB_Assignment2.Models.Assignment", "Assignment")
                        .WithMany("HelpRequests")
                        .HasForeignKey("AssignmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAB_Assignment2.Models.Student", "Student")
                        .WithMany("HelpRequests")
                        .HasForeignKey("StudentAUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DAB_Assignment2.Models.StudentCourse", b =>
                {
                    b.HasOne("DAB_Assignment2.Models.Course", "Course")
                        .WithMany("StudentCourses")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAB_Assignment2.Models.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("StudentAUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DAB_Assignment2.Models.Teacher", b =>
                {
                    b.HasOne("DAB_Assignment2.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
