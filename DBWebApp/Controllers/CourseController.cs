using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAB_Assignment2.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DBWebApp.Controllers
{
    [Route("api/[controller]")]
    public class CourseController : Controller
    {
        Assignment2Context context = new Assignment2Context();

        // GET: api/<controller>
        [HttpGet]
        public List<Course> GetAllCourses()
        {
            return context.Courses.ToList();
        }



        // GET api/<controller>/Stats/101
        [HttpGet("Stats/{CourseID}")]
        public string Stats(int courseID)
        {
            var allExercises = context.Exercises.Where(e => e.CourseID == courseID);
            var assignmentHelpRequests = context.HelpRequests.Where(h => h.Assignment.CourseID == courseID);


            
            int all = allExercises.Count() + assignmentHelpRequests.Count();
            int closed = allExercises.Count(e => e.Open == false) + assignmentHelpRequests.Count(h => h.Open == false);

            return $"Of {all} helprequests in this course, {closed} have been closed.";
        }

        // GET api/<controller>/Create/Dabbing/101
        [HttpGet("Create/{courseName}")]
        public string CreateCourse(string courseName)
        {
            var course = new Course()
            {
                Name = courseName
            };

            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Add(course);
                    context.SaveChanges();
                    transaction.Commit();
                    return "Course have been added";
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return "Course could not be added. This combination of name and ID already exitst";
                }
            }
        }


        // Get api/<controller>/AddToCourse/au604643/4/1/4
        [HttpGet("AddStudent/{studentID}/{courseID}/{active}/{semester}")]
        public string AddStudent(string studentID, int courseID, bool active, int semester)
        {
            var sc = new StudentCourse()
            {
                StudentAUID = studentID,
                CourseID = courseID,
                Active = active,
                Semester = semester
            };

            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Add(sc);
                    context.SaveChanges();
                    transaction.Commit();
                    return "Student have been added";
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return "Student could not be added to course.";
                }
            }
        }
    }
}
