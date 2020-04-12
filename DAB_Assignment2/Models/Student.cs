using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace DAB_Assignment2.Models
{
    public class Student
    {
        public string Name { get; set; }
        [Key]
        public string AUID { get; set; }

        

        public List<StudentCourse> StudentCourses { get; set; }
        public List<StudentAssignment> StudentAssignments { get; set; }

    }
}
