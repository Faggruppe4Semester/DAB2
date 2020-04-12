using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAB_Assignment2.Models
{
    public class Assignment
    {


        public int CourseID { get; set; }
        public Course Course { get; set; }

        public string TeacherAUID { get; set; }
        public Teacher Teacher { get; set; }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AssignmentID { get; set; }

        public List<StudentAssignment> StudentAssignments { get; set; }


    }

    public class StudentAssignment
    {
        public string StudentAUID { get; set; }
        public Student Student { get; set; }

        public int AssignmentID { get; set; }
        public Assignment Assignment { get; set; }

    }
}
