using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAB_Assignment2.Models
{
    public class Teacher
    {
        public string name { get; set; }
        [Key]
        public string AUID { get; set; }

        public int CourseID { get; set; }
        public Course Course { get; set; }


    }
}
