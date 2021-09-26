using AutoMapper;
using FacilitiesManagementAPI.DTOs;
using FacilitiesManagementAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FacilitiesManagementAPI.Controllers
{
    public class PremisesTasksController : Controller
    {
        private readonly IPremisesTask _premisesTask;
        private readonly IMapper _mapper;

        public PremisesTasksController(IPremisesTask premisesTask, IMapper mapper)
        {
            _premisesTask = premisesTask;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task <ActionResult<IEnumerable<PropertyTasksDto>>> GetPropTasks()
        {
            var propTasks = _premisesTask.GetTasks();
            return Ok(propTasks);  
        }

        [HttpGet("Id")]
        public async Task <ActionResult<PropertyTasksDto>> GetPropTaskByIdAsync(int id)
        {
            return await _premisesTask.GetPropertyTaskByIdAsync(id);
        }
     }
}
