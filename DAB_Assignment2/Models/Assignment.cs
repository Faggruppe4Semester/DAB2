using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAB_Assignment2.Models
{
    public class Assignment
    {
        public int AssignmentID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }
        public Course Course { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string TeacherAUID { get; set; }
        public Teacher Teacher { get; set; }

        public List<HelpRequest> HelpRequests { get; set; }


    }

    public class HelpRequest
    {
        public bool Open { get; set; }
        public string StudentAUID { get; set; }
        public Student Student { get; set; }

        public int AssignmentID { get; set; }
        public Assignment Assignment { get; set; }

    }
}
