using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CMS.Models
{
    public class Projects
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Client { get; set; }
        public string Project_Manager { get; set; }
        public decimal Revenue { get; set; }
        public decimal Revenue_ClientCurrency { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DeadLine { get; set; }
        public string Status { get; set; }
        public string Task { get; set; }
        public int TaskCount { get; set; }

    }

   
}
