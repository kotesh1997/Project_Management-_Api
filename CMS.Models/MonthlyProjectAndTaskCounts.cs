using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Models
{
    public class MonthlyProjectAndTaskCounts
    {
        public string YearMonth { get; set; }
        public int TotalProjects { get; set; }
        public int TotalTasks { get; set; }
    }

}
