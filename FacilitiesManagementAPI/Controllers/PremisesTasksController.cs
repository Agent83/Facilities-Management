﻿using AutoMapper;
using FacilitiesManagementAPI.Data;
using FacilitiesManagementAPI.DTOs;
using FacilitiesManagementAPI.Entities;
using FacilitiesManagementAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FacilitiesManagementAPI.Controllers
{
    public class PremisesTasksController : BaseApiController
    {
        private readonly IPremisesTaskRepository _premisesTask;
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public PremisesTasksController(IPremisesTaskRepository premisesTask, IMapper mapper, DataContext context)
        {
            _premisesTask = premisesTask;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task <ActionResult<IEnumerable<PropertyTasksDto>>> GetPropTasks()
        {
            var propTasks = await _premisesTask.GetTasks();
            return Ok(propTasks);  
        }

        [HttpGet("Id")]
        public async Task <ActionResult<PropertyTasksDto>> GetPropTaskByIdAsync(Guid id)
        {
            return await _premisesTask.GetPropertyTaskByIdAsync(id);
        }


        [HttpPost("createTask")]
        public async Task<ActionResult<PremisesTask>> CreateTask(PropertyTasksDto propertyTasksDto)
        {
            var propTask = _mapper.Map<PremisesTask>(propertyTasksDto);

            _context.PremisesTask.Add(propTask);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateTask(PropertyTasksDto propertyTasksDto)
        {
            var propertyTask = await _premisesTask.GetPremiseTaskByIdAsync(propertyTasksDto.Id);
            _mapper.Map(propertyTasksDto, propertyTask);

            _premisesTask.Update(propertyTask);

            if (await _premisesTask.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to update task");
        }

    }
}
