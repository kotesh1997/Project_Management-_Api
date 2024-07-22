using CMS.Models;
using CMS.Service;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Repository
{
    public class Project_ManagementRepository : IProject_ManagementRepository
    {
        private readonly IDapper dapper;
        public Project_ManagementRepository(IDapper _dapper)
        {
            dapper = _dapper;
        }

    

        public List<Projects> GetAllProjects()
        {
            var dbParam = new DynamicParameters();
            var result = dapper.GetAll<Projects>("[dbo].[SP_Get_AllProjects]", dbParam, commandType: CommandType.StoredProcedure);
            return result;
        }

        public Projects GetProjecstById(int id)
        {
            var dbParam = new DynamicParameters();
            dbParam.Add("Id", id, DbType.Int32);
            var result = dapper.Get<Projects>("[dbo].[SP_Get_ProjectById]", dbParam, commandType: CommandType.StoredProcedure);
            return result;
        }

        public Projects AddProject(Projects project)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Code", project.Code);
                parameters.Add("@Name", project.Name);
                parameters.Add("@Client", project.Client);
                parameters.Add("@Project_Manager", project.Project_Manager);
                parameters.Add("@Revenue", project.Revenue);
                parameters.Add("@Revenue_ClientCurrency", project.Revenue_ClientCurrency);
                parameters.Add("@StartDate", project.StartDate);
                parameters.Add("@DeadLine", project.DeadLine);
                parameters.Add("@Status", project.Status);
                parameters.Add("@Task", project.Task);

                var result = dapper.Get<Projects>("SP_Add_Project", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (SqlException ex) when (ex.Number == 50000) 
            {
                throw new Exception(ex.Message);
            }
        }

        public Projects UpdateProject(Projects project)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", project.Id);
                parameters.Add("@Code", project.Code);
                parameters.Add("@Name", project.Name);
                parameters.Add("@Client", project.Client);
                parameters.Add("@Project_Manager", project.Project_Manager);
                parameters.Add("@Revenue", project.Revenue);
                parameters.Add("@Revenue_ClientCurrency", project.Revenue_ClientCurrency);
                parameters.Add("@StartDate", project.StartDate);
                parameters.Add("@DeadLine", project.DeadLine);
                parameters.Add("@Status", project.Status);
                parameters.Add("@Task", project.Task);

                var result = dapper.Get<Projects>("[dbo].[SP_Update_Project]", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                throw ex;
            }
        }


        //public int DeleteProject(int id)
        //{
        //    try
        //    {
        //        var parameters = new DynamicParameters();
        //        parameters.Add("@Id", id, DbType.Int32);
        //        parameters.Add("@Message", dbType: DbType.String, direction: ParameterDirection.Output, size: 255);

        //        dapper.Execute("[dbo].[SP_Delete_Project]", parameters, commandType: CommandType.StoredProcedure);

        //        string message = parameters.Get<string>("@Message");
        //        Console.WriteLine(message); // You can log this message or handle it as needed

        //        return 1; // Assuming 1 indicates success
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log or handle the exception
        //        throw ex;
        //    }
        //}
        public int DeleteProject(int id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id, DbType.Int32);
                parameters.Add("@result", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                dapper.Execute("[dbo].[SP_Delete_Project]", parameters, commandType: CommandType.StoredProcedure);

                int result = parameters.Get<int>("@result");
                return result;
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                throw ex;
            }
        }


        //public int AddService(ServiceDetails service)
        //{
        //    try
        //    {
        //        var parameters = new DynamicParameters();
        //        parameters.Add("@ServiceID", dbType: DbType.Int32, direction: ParameterDirection.Output);
        //        parameters.Add("@ServiceName", service.ServiceName);
        //        parameters.Add("@CreatedDate", DateTime.Now);
        //        parameters.Add("@ModifiedDate", DateTime.Now);
        //        parameters.Add("@Price", service.Price);
        //        parameters.Add("@GST", service.GST);
        //        parameters.Add("@ServiceOwner", service.ServiceOwner);
        //        parameters.Add("@Action", "Save");
        //        parameters.Add("@result", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue); // Add ReturnValue parameter

        //        dapper.Execute("SP_Add_Service", parameters, commandType: CommandType.StoredProcedure);

        //        int result = parameters.Get<int>("@result");

        //        if (result > 0)
        //        {
        //            return result;
        //        }
        //        else
        //        {
        //            throw new Exception("Error occurred while adding service. Stored procedure execution failed.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log or handle exception
        //        throw ex;
        //    }
        //}




        //public  int UpdateService(ServiceDetails service)
        //{
        //    try
        //    {
        //        var existingdata = GetserviceById(service.ServiceId);
        //        var parameters = new DynamicParameters();
        //        parameters.Add("@ServiceID", service.ServiceId);
        //        parameters.Add("@ServiceName", service.ServiceName);
        //        parameters.Add("@CreatedDate", existingdata.Createddate);
        //        parameters.Add("@ModifiedDate", DateTime.Now);
        //        parameters.Add("@Price", service.Price);
        //        parameters.Add("@GST", service.GST);
        //        parameters.Add("@ServiceOwner", service.ServiceOwner);
        //        parameters.Add("@Action", "Update"); // Set action to 'Update'
        //        parameters.Add("@result", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

        //        dapper.Execute("SP_Add_Service", parameters, commandType: CommandType.StoredProcedure);

        //        int result = parameters.Get<int>("@result");

        //        if (result > 0)
        //        {
        //            return result;
        //        }
        //        else
        //        {
        //            throw new Exception("Error occurred while updating service. Stored procedure execution failed.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public int DeleteService(int ServiceId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ServiceID", ServiceId, DbType.Int32);
                parameters.Add("@result", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                dapper.Execute("[dbo].[SP_DeleteServiceById]", parameters, commandType: CommandType.StoredProcedure);

                int result = parameters.Get<int>("@result");
                return result;
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                throw ex;
            }
        }

        public List<ProjectTasks> GetAllProjectTasks()
        {
            var dbParam = new DynamicParameters();
            var result = dapper.GetAll<ProjectTasks>("[dbo].[SP_Get_AllProjectTasks]", dbParam, commandType: CommandType.StoredProcedure);
            return result;
        }

    public ProjectTasks GetProjectTaskById(int id)
    {
        var dbParam = new DynamicParameters();
        dbParam.Add("Id", id, DbType.Int32);
        var result = dapper.Get<ProjectTasks>("[dbo].[SP_Get_ProjectTaskById]", dbParam, commandType: CommandType.StoredProcedure);
        return result;
    }

        public ProjectTasks AddProjectTasks(ProjectTasks projectTask)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Tittle", projectTask.Tittle);
                parameters.Add("@Description", projectTask.Description);
                parameters.Add("@AssignedTo", projectTask.AssignedTo);
                parameters.Add("@AssignedBy", projectTask.AssignedBy);
                parameters.Add("@ProjectId", projectTask.ProjectId);
                var result = dapper.Get<ProjectTasks>("[dbo].[SP_Insert_ProjectTask]", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (SqlException ex) when (ex.Number == 50000)
            {
                throw new Exception(ex.Message);
            }
        }
        public ProjectTasks UpdateProjectTask(ProjectTasks projectTask)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", projectTask.Id);
                parameters.Add("@Tittle", projectTask.Tittle);
                parameters.Add("@Description", projectTask.Description);
                parameters.Add("@AssignedTo", projectTask.AssignedTo);
                parameters.Add("@AssignedBy", projectTask.AssignedBy);
                parameters.Add("@ProjectId", projectTask.ProjectId);

                var result = dapper.Get<ProjectTasks>("[dbo].[SP_Update_ProjectTask]", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                throw ex;
            }
        }

        public int DeleteProjectTask(int id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id, DbType.Int32);
                parameters.Add("@result", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                dapper.Execute("[dbo].[SP_Delete_ProjectTask]", parameters, commandType: CommandType.StoredProcedure);

                int result = parameters.Get<int>("@result");
                return result;
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                throw ex;
            }
        }

        public List<ReportsCount> GetReportsCount()
        {
            var dbParam = new DynamicParameters();
            var result = dapper.GetAll<ReportsCount>("[dbo].[SP_Get_ProjectAndTaskCounts]", dbParam, commandType: CommandType.StoredProcedure);
            return result;
        }
        public List<ProjectTaskCount> GetProjectTaskCounts()
        {
            var dbParam = new DynamicParameters();
            var result = dapper.GetAll<ProjectTaskCount>("[dbo].[SP_Get_ProjectTaskCounts]", dbParam, commandType: CommandType.StoredProcedure);
            return result;
        }
        public List<MonthlyProjectAndTaskCounts> GetMonthlyProjectAndTaskCounts(int fromYear, int toYear)
        {
            var dbParam = new DynamicParameters();
            dbParam.Add("@FromYear", fromYear, DbType.Int32);
            dbParam.Add("@ToYear", toYear, DbType.Int32);
            var result = dapper.GetAll<MonthlyProjectAndTaskCounts>("[dbo].[SP_Get_MonthlyProjectAndTaskCounts]", dbParam, commandType: CommandType.StoredProcedure);
            return result;
        }

        public TotalCounts GetTotalCounts()
        {
            var result = dapper.Get<TotalCounts>("[dbo].[SP_Get_TotalCounts]", null, commandType: CommandType.StoredProcedure);
            return result;
        }
       




    }
}

