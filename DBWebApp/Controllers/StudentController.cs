using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
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
    public class StudentController : Controller
    {
        Assignment2Context context = new Assignment2Context();


        // GET: api/<controller>
        [HttpGet]
        public List<Exercise> GetAllOpenHelpRequests()
        {
            return context.Exercises.Include(e => e.Student).Include(e => e.Teacher).Include(e => e.Course).ToList();
        }

        // GET api/<controller>/au454545
        [HttpGet("{id}")]
        public List<Exercise> GetHelpRequestFromStudent(string id)
        {
            return context.Exercises.Include(e => e.Student).Include(e => e.Teacher).Include(e => e.Course).ToList().Where(e => e.StudentAUID == id).ToList();
        }

        // Get api/<controller>/Create/John/au454545
        [HttpGet("Create/{studentName}/{studentID}")]
        public string CreateStudent(string studentName, string studentID)
        {
            var student = new Student()
            {
                Name = studentName,
                AUID = studentID
            };

            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Add(student);
                    context.SaveChanges();
                    transaction.Commit();
                    return "Student have been added";
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return "Student could not be added. Student with this AUID already exists.";
                }
            }
        }

        // Get api/<controller>/AddToCourse/au000000/2/1/4
        [HttpGet("AddToCourse/{studentID}/{courseID}/{active}/{semester}")]
        public string AddToCourse(string studentID, int courseID, bool active, int semester)
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
