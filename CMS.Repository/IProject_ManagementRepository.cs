using CMS.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Repository
{
    public interface IProject_ManagementRepository
    {
        List<Projects> GetAllProjects();
        Projects GetProjecstById(int id);
        Projects AddProject(Projects project);
        Projects UpdateProject(Projects project);
        int DeleteProject(int id);
        int DeleteService(int ServiceId);
        List<ProjectTasks> GetAllProjectTasks();
        ProjectTasks GetProjectTaskById(int id);
        ProjectTasks AddProjectTasks(ProjectTasks projectTask);
        ProjectTasks UpdateProjectTask(ProjectTasks projectTask);
        int DeleteProjectTask(int id);
        List<ProjectTaskCount> GetProjectTaskCounts();
        List<ReportsCount> GetReportsCount();
        TotalCounts GetTotalCounts();
        List<MonthlyProjectAndTaskCounts> GetMonthlyProjectAndTaskCounts(int fromYear, int toYear);
       
    }
}
