using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseFirstApproachEF_WebAPI_Consume.Models
{
    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        public string designation { get; set; }
        public int salary { get; set; }
    }
}