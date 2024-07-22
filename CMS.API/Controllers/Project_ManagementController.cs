using CMS.Models;
using CMS.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CMS.API.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Project_ManagementController : ControllerBase
    {
        private readonly IProject_ManagementRepository serviceRepository ;
        private readonly ILogger<Project_ManagementController> logger;
        public Project_ManagementController(IProject_ManagementRepository _serviceRepository, ILogger<Project_ManagementController> _logger)
        {
            serviceRepository = _serviceRepository;
            logger = _logger;
        }
        [EnableCors("CorsPolicy")]
        [HttpGet]
        public async Task<ActionResult<Projects>> GetAllProjects()
        {
            try
            {
                var result = await Task.FromResult(serviceRepository.GetAllProjects());
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at GetAllProjects Method: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
       
        [EnableCors("CorsPolicy")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Projects>> GetProjectsById(int id)
        {
            try
            {
                var result = await Task.FromResult(serviceRepository.GetProjecstById(id));
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at GetProjectsById Method: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        [EnableCors("CorsPolicy")]
        [HttpPost]
        public async Task<ActionResult<Projects>> AddProject([FromBody] Projects project)
        {
            try
            {
                var result = await Task.FromResult(serviceRepository.AddProject(project));
                return Ok(new { Status = "OK", Data = result });
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at AddProject Method: {ex}");
                return BadRequest(ex.Message);
            }
        }
        [EnableCors("CorsPolicy")]
        [HttpPut]
        public async Task<ActionResult<Projects>> UpdateProject([FromBody] Projects project)
        {
            try
            {
                var result = await Task.FromResult(serviceRepository.UpdateProject(project));
                return Ok(new { Status = "OK", Data = result });
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at UpdateProject Method: {ex}");
                return BadRequest(ex.Message);
            }
        }

        [EnableCors("CorsPolicy")]
        [HttpDelete("DeleteProjectbyId")]
        public async Task<ActionResult<int>> DeleteProject(int id)
        {
            try
            {
                var result = await Task.FromResult(serviceRepository.DeleteProject(id));
                return Ok(new { Status = "OK", Data = result });
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at DeleteProject Method: {ex}");
                return BadRequest(ex.Message);
            }
        }
        [EnableCors("CorsPolicy")]
        [HttpGet]
        public async Task<ActionResult<List<ProjectTasks>>> GetAllProjectTasks()
        {
            try
            {
                var result = await Task.FromResult(serviceRepository.GetAllProjectTasks());
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at GetAllProjectTasks Method: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [EnableCors("CorsPolicy")]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectTasks>> GetProjectTaskById(int id)
        {
            try
            {
                var result = await Task.FromResult(serviceRepository.GetProjectTaskById(id));
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at GetProjectTaskById Method: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [EnableCors("CorsPolicy")]
        [HttpPost]
        public async Task<ActionResult<ProjectTasks>> AddProjectTask([FromBody] ProjectTasks projectTask)
        {
            try
            {
                var result = await Task.FromResult(serviceRepository.AddProjectTasks(projectTask));
                return Ok(new { Status = "OK", Data = result });
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at AddProjectTask Method: {ex}");
                return BadRequest(ex.Message);
            }
        }

        [EnableCors("CorsPolicy")]
        [HttpPut]
        public async Task<ActionResult<ProjectTasks>> UpdateProjectTask([FromBody] ProjectTasks projectTask)
        {
            try
            {
                var result = await Task.FromResult(serviceRepository.UpdateProjectTask(projectTask));
                return Ok(new { Status = "OK", Data = result });
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at UpdateProjectTask Method: {ex}");
                return BadRequest(ex.Message);
            }
        }

        [EnableCors("CorsPolicy")]
        [HttpDelete("DeleteProjectTask")]
        public async Task<ActionResult<int>> DeleteProjectTask(int id)
        {
            try
            {
                var result = await Task.FromResult(serviceRepository.DeleteProjectTask(id));
                return Ok(new { Status = "OK", Data = result });
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at DeleteProjectTask Method: {ex}");
                return BadRequest(ex.Message);
            }
        }
        [EnableCors("CorsPolicy")]
        [HttpGet("GetReportsCount")]
        public async Task<ActionResult<List<ReportsCount>>> GetReportsCount()
        {
            try
            {
                var taskCounts = await Task.FromResult(serviceRepository.GetReportsCount());
                return Ok(new { Status = "OK", Data = taskCounts });
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, ex.Message);
            }
        }
       

        [EnableCors("CorsPolicy")]
        [HttpGet("monthly_ReportsCount")]
        public IActionResult Getmonthly_ReportsCount(int fromYear, int toYear)
        {
            try
            {
                var result = serviceRepository.GetMonthlyProjectAndTaskCounts(fromYear, toYear);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [EnableCors("CorsPolicy")]
        [HttpGet("totalcounts")]
        public IActionResult GetTotalCounts()
        {
            try
            {
                var result = serviceRepository.GetTotalCounts();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        
       

    }
}
