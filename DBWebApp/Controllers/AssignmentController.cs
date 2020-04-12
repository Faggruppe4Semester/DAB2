using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DAB_Assignment2.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DBWebApp.Controllers
{
    [Route("api/[controller]")]
    public class AssignmentController : Controller
    {

        Assignment2Context context = new Assignment2Context();

        // GET api/<controller>/Create/420/101/au111000
        [HttpGet("Create/{AssignmentID}/{CourseID}/{TeacherID}")]
        public string CreateAssignment(int assignmentID, int courseID, string teacherID)
        {
            var assignment = new Assignment()
            {
                AssignmentID = assignmentID,
                TeacherAUID = teacherID,
                CourseID = courseID
            };

            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Add(assignment);
                    context.SaveChanges();
                    transaction.Commit();
                    return "Assignment have been added";
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return "Assignment could not be added.";
                }
            }
        }

        // GET api/<controller>/AddStudent/420/au123654
        [HttpGet("AddStudent/{AssignmentID}/{studentID}")]
        public string AddStudent(int assignmentID, string studentID)
        {
            var sa = new StudentAssignment()
            {
                AssignmentID = assignmentID,
                StudentAUID = studentID
            };

            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Add(sa);
                    context.SaveChanges();
                    transaction.Commit();
                    return "Student have been added to assignment";
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return "Student could not be added.";
                }
            }
        }

    }
}
