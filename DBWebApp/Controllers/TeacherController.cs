using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAB_Assignment2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DBWebApp.Controllers
{
    [Route("api/[controller]")]
    public class TeacherController : Controller
    {
        Assignment2Context context = new Assignment2Context();

        // Get api/<controller>/Create/Per/au123321
        [HttpGet("Create/{TeacherName}/{TeacherID}/{CourseID}")]
        public string CreateTeacher(string teacherName, string teacherID, int courseID)
        {
            var teacher = new Teacher()
            {
                name = teacherName,
                AUID = teacherID,
                CourseID = courseID
            };

            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Add(teacher);
                    context.SaveChanges();
                    transaction.Commit();
                    return "Teacher have been added";
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return "Teacher could not be added. Teacher with this AUID already exists.";
                }
            }
        }

        // GET api/<controller>/AU000000/1
        [HttpGet("{TeacherID}/{courseID}")]
        public List<Object> PrintOpenHelpRequest(string TeacherID, int CourseID)
        {
            var exerciseRequests = context.Exercises
                .Include(e => e.Student)
                .Where(e => CourseID == e.CourseID)
                .Where(e => TeacherID.ToUpper() == e.TeacherAUID.ToUpper())
                .Where(e => e.Open == true)
                .ToList();

            var assignmentRequests = context.Assignments
                .Where(a => a.CourseID == CourseID && a.TeacherAUID.ToUpper() == TeacherID.ToUpper())
                .Include(a => a.HelpRequests)
                .ThenInclude(h => h.Open)
                .ToList();

            List<Object> allRequests = (from x in exerciseRequests select (Object)x).ToList();
            allRequests.AddRange((from x in assignmentRequests select (Object)x).ToList());

            return allRequests;
        }
    }
}
