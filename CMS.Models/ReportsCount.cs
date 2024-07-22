using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Models
{
    
    public class ReportsCount
    {
        public int TotalProjects { get; set; }
        public int ProjectId {  get; set; }
        public int TaskCount { get; set; }
    }
    public class TotalCounts
    {
        public int TotalProjectsCount { get; set; }
        public int TotalTasksCount { get; set; }
        public int TotalActiveProjectsCount { get; set; }
        public int TotalInactiveProjectsCount { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TotalRevenueInClientCurrency { get; set; }
    }

}
