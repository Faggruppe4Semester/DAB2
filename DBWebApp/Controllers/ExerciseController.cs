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
    public class ExerciseController : Controller
    {
        Assignment2Context context = new Assignment2Context();

        // GET api/<controller>/AU000000/1
        [HttpGet("{TeacherID}/{courseID}")]
        public List<Exercise> PrintOpenHelpRequest(string TeacherID, int CourseID)
        {
            return context.Exercises
                .Include(e => e.Student)
                .Where(e => CourseID == e.CourseID)
                .Where(e => TeacherID.ToUpper() == e.TeacherAUID.ToUpper())
                .Where(e => e.Open == true)
                .ToList();
        }


        // GET api/<controller>/Create/Uge2/1/PBA/1/au123321/au987456/2
        [HttpGet("Create/{Lecture}/{Number}/{Where}/{open}/{TeacherID}/{studentID}/{CourseID}")]
        public string CreateExercise(string lecture, int number, string where, bool open, string teacherID, string studentID, int courseID)
        {
            var exercise = new Exercise()
            {
                Lecture = lecture,
                Number = number,
                Help_Where = where,
                Open = open,
                TeacherAUID = teacherID,
                StudentAUID = studentID,
                CourseID = courseID
            };

            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Add(exercise);
                    context.SaveChanges();
                    transaction.Commit();
                    return "Exercise have been added";
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return "Exercise could not be added.";
                }
            }
        }

        // GET api/<controller>/Update/Uge2/1/Shannon
        [HttpGet("Update/{Lecture}/{Number}/{Where}")]
        public string ChangeLocation(string lecture, int number, string where)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var exercise = context.Exercises.Single(e => e.Lecture == lecture && e.Number == number);
                    exercise.Help_Where = where;
                    context.SaveChanges();
                    transaction.Commit();
                    return "Location of exercise have been changed";
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return "Location of exercise could not be changed.";
                }
            }
        }

        // GET api/<controller>/Update/Uge2/1/au111000
        [HttpGet("Update/{Lecture}/{Number}/{TeacherID}")]
        public string ChangeTeacher(string lecture, int number, string teacherID)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var exercise = context.Exercises.Single(e => e.Lecture == lecture && e.Number == number);
                    exercise.TeacherAUID = teacherID;
                    context.SaveChanges();
                    transaction.Commit();
                    return "Exercise have been transferred to another teacher.";
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return "Exercise could not be transferred to another teacher.";
                }
            }
        }

        // GET api/<controller>/Update/Uge2/1/au123654
        [HttpGet("Update/{Lecture}/{Number}/{StudentID}")]
        public string ChangeStudent(string lecture, int number, string studentID)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var exercise = context.Exercises.Single(e => e.Lecture == lecture && e.Number == number);
                    exercise.StudentAUID = studentID;
                    context.SaveChanges();
                    transaction.Commit();
                    return "Exercise have been transferred to another student.";
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return "Exercise could not be transferred to another student.";
                }
            }
        }


        // GET api/<controller>/Update/Uge2/1/101
        [HttpGet("Update/{Lecture}/{Number}/{CourseID}")]
        public string ChangeCourse(string lecture, int number, int courseID)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var exercise = context.Exercises.Single(e => e.Lecture == lecture && e.Number == number);
                    exercise.CourseID = courseID;
                    context.SaveChanges();
                    transaction.Commit();
                    return "Exercise have been transferred to another course.";
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return "Exercise could not be transferred to another course.";
                }
            }
        }

        // GET api/<controller>/Update/Uge2/1/0
        [HttpGet("UpdateOpen/{Lecture}/{Number}/{active}")]
        public string UpdateOpen(string lecture, int number, bool active)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var exercise = context.Exercises.Single(e => e.Lecture == lecture && e.Number == number);
                    exercise.Open = active;
                    context.SaveChanges();
                    transaction.Commit();
                    return "Exercise have changed active-status";
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return "Active-status of exercise could not be changed";
                }
            }
        }


    }
}
