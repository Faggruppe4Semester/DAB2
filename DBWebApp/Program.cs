using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using DAB_Assignment2.Models;

namespace DBWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {

            using(var db = new Assignment2Context())
            {
                db.Database.ExecuteSqlCommand("delete from HelpRequests");
                db.Database.ExecuteSqlCommand("delete from StudentCourses");
                db.Database.ExecuteSqlCommand("delete from HelpRequests");
                db.Database.ExecuteSqlCommand("delete from Exercises");
                db.Database.ExecuteSqlCommand("delete from Courses");
                db.Database.ExecuteSqlCommand("delete from Teachers");
                db.Database.ExecuteSqlCommand("delete from Students");


                var student = new Student()
                {
                    Name = "Jokum",
                    AUID = "AU785594"
                };
                db.Add(student);
                db.SaveChanges();

                var student3 = new Student()
                {
                    Name = "Jordkim",
                    AUID = "AU789456"
                };
                db.Add(student3);
                db.SaveChanges();


                var student2 = new Student()
                {
                    Name = "DJDudeMan",
                    AUID = "AU223684"
                };
                db.Add(student2);
                db.SaveChanges();


                var course = new Course()
                {
                    Name = "Avanceret Løgspark"
                };

                db.Add(course);

                var course2 = new Course()
                {
                    Name = "Matematik"
                };
                db.Add(course2);
                db.SaveChanges();

                db.Add(new StudentCourse() //Add a student to a course
                {
                    Active = true,
                    CourseID = course.CourseID,
                    Semester = 2,
                    StudentAUID = student.AUID
                });

                db.Add(new StudentCourse() //Add another student to the same course
                {
                    Active = true,
                    CourseID = course.CourseID,
                    StudentAUID = student2.AUID
                });

                db.SaveChanges();

                Teacher teacher2 = new Teacher()
                {
                    name = "Karl Jorgen",
                    AUID = "AU555555",
                    CourseID = course2.CourseID
                };

                Teacher teacher1 = new Teacher()
                {
                    name = "Dr. John",
                    AUID = "AU000000",
                    CourseID = course.CourseID
                };

                db.SaveChanges();


                Exercise E1 = new Exercise()
                {
                    Number = 0,
                    Lecture = "English",
                    Help_Where = "Auditoriet",
                    Student = student,
                    Teacher = teacher1,
                    Course = course,
                    Open = true
                };
                db.Add(E1);

                Exercise E2 = new Exercise()
                {
                    Number = 420,
                    Lecture = "Danks",
                    Help_Where = "PBA",
                    Student = student,
                    Teacher = teacher1,
                    Course = course,
                    Open = true
                };
                db.Add(E2);

                Exercise E3 = new Exercise()
                {
                    Number = 545,
                    Lecture = "Danks",
                    Help_Where = "PBA",
                    Student = student2,
                    Teacher = teacher2,
                    Course = course2
                };
                db.Add(E3);
                db.SaveChanges();

                var A1 = new Assignment()
                {
                    CourseID = course.CourseID,
                    TeacherAUID = teacher1.AUID
                };

                db.Add(A1);
                db.SaveChanges();

                var A1Students = new HelpRequest()
                {
                    Open = false,
                    AssignmentID = A1.AssignmentID,
                    StudentAUID = student.AUID
                };

                db.Add(A1Students);
                
                var A1Students2 = new HelpRequest()
                {
                    Open = true,
                    AssignmentID = A1.AssignmentID,
                    StudentAUID = student2.AUID
                };

                db.Add(A1Students2);

                db.SaveChanges();
            }

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
