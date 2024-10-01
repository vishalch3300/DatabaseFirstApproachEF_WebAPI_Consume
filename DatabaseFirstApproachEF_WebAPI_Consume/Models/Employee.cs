using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DatabaseFirstApproachEF_WebAPI_Consume.Models
{
    public class Employee
    {
        [Display(Name = "Id")]
        public int id { get; set; }

        [Display(Name = "Name")]
        public string name { get; set; }
        
        [Display(Name = "Gender")]
        public string gender { get; set; }

        [Display(Name = "Age")]
        public int age { get; set; }

        [Display(Name = "Designation")]
        public string designation { get; set; }

        [Display(Name = "Salary")]
        public int salary { get; set; }
    }
}