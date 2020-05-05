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

        // GET api/<controller>/au454545
        [HttpGet("{id}")]
        public List<Exercise> GetHelpRequestFromStudent(string id)
        {
            var exerciseRequests  = context.Exercises.Include(e => e.Student)
                .Include(e => e.Teacher)
                .Include(e => e.Course)
                .Where(e => e.StudentAUID == id)
                .Where(e => e.Open == true)
                .ToList();
            //var assignmnetRequests = context.HelpRequests.Include(h => h.Student)
                //.Include(h => h.Assignment)
                //.Where(h => h.StudentAUID == id)
                //.Where(h => h.Open == true)
                //.ToList();

            List<Object> allRequests = (from x in exerciseRequests select (Object) x).ToList();
            //allRequests.AddRange((from x in assignmnetRequests select (Object)x).ToList());

            return exerciseRequests;
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

        [HttpGet("CreateHelpRequest/{studentId}/{assignmentId}")]
        public string CreateHelpRequest(string studentId, int assignmentId)
        {
            var student = context.Students.FirstOrDefault(s => s.AUID == studentId);
            var assignment = context.Assignments.FirstOrDefault(a => a.AssignmentID == assignmentId);

            var request = new HelpRequest()
            {
                Open = true,
                Assignment = assignment,
                Student = student
            };

            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Add(request);
                    context.SaveChanges();
                    transaction.Commit();
                    return "Help-request created";
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return "Failed creating request, request possibly already exists";
                }
            }
        }

        [HttpGet("UpdateHelpRequest/{studentId}/{assignmentId}/{status}")]
        public string UpdateHelpRequest(string studentId,int assignmentId, bool status)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var helpRequest = context.HelpRequests.FirstOrDefault(hr =>
                        hr.StudentAUID == studentId && hr.AssignmentID == assignmentId);
                    if (helpRequest != null) helpRequest.Open = status;
                    context.SaveChanges();
                    transaction.Commit();
                    return $"Changed status of request to {status}";
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return "Failed changing status of request";
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
