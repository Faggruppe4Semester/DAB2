using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAB_Assignment2.Models
{
    public class Exercise
    {
        public string Help_Where { get; set; }
        public string Lecture { get; set; }
        public int Number { get; set; }

        public bool Open { get; set; }

        public string StudentAUID { get; set; }
        public Student Student { get; set; }

        public string TeacherAUID { get; set; }
        public Teacher Teacher { get; set; }

        public int CourseID { get; set; }
        public Course Course { get; set; }

    }
}
