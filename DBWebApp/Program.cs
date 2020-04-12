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
                
                db.Database.ExecuteSqlCommand("delete from Exercises");
                db.Database.ExecuteSqlCommand("delete from Teachers");
                db.Database.ExecuteSqlCommand("delete from Courses");
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
                    Name = "Avanceret Løgspark",
                    CourseID = 1
                };

                db.Add(course);

                var course2 = new Course()
                {
                    Name = "Matematik",
                    CourseID = 2
                };
                db.Add(course2);
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
                    Course = course
                };
                db.Add(E1);

                Exercise E2 = new Exercise()
                {
                    Number = 420,
                    Lecture = "Danks",
                    Help_Where = "PBA",
                    Student = student,
                    Teacher = teacher1,
                    Course = course
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
