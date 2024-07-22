using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Models
{
    public class ProjectTasks
    {
        [Key]
        public int Id { get; set; }
        public string Tittle { get; set; }
        public string Description { get; set; }
        public string AssignedTo { get; set; }
        public string AssignedBy { get; set; }

        public int ProjectId { get; set; }
    }
}
