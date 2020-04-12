using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAB_Assignment2.Models
{
    public class Course
    {
        public string Name { get; set; }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }

        public List<StudentCourse> StudentCourses { get; set; }

    }

    public class StudentCourse
    {
        public string StudentAUID { get; set; }
        public Student Student { get; set; }
        public int CourseID { get; set; }
        public Course Course { get; set; }
        public bool Active { get; set; }
        public int Semester { get; set; }


    }
}
