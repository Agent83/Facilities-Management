using AutoMapper;
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
    public class PremiseController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IPremiseRepository _premise;
        private readonly IPremisesTaskRepository _premisesTask;
        private readonly DataContext _context;

        public PremiseController(IMapper mapper, IPremiseRepository premise, DataContext context
                                  , IPremisesTaskRepository premisesTask)
        {
            _mapper = mapper;
            _premise = premise;
            _context = context;
            _premisesTask = premisesTask;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PropertyDto>>> GetPremises()
        {
            var premises = await _premise.GetPropertiesAsync();
            return Ok(premises);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyDto>> GetProperty(Guid id)
        {
            return await _premise.GetPropertyByIdAsync(id);
        }
    
        [HttpPost("property")]
        public async Task<ActionResult<PropertyDto>> CreateProperty(CreatePropertyDto propertyDto)
        {
            var premise = _mapper.Map<Premises>(propertyDto);
 
            _context.Premises.Add(premise);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePremise(UpdatePremiseDto propertyDto)
        {
            var premise = await _premise.GetPremiseByIdAsync(propertyDto.Id);
            _mapper.Map(propertyDto, premise);

            _premise.Update(premise);

            if(await _premise.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to update property");
        }

        [HttpPost("createTask")]
        public async Task<ActionResult<PremisesTask>> CreateContractor(PropertyTasksDto propertyTasksDto)
        {
           // var property = await _premise.GetPremiseByIdAsync(propertyTasksDto.PremisesId);
            var propTask = _mapper.Map<PremisesTask>(propertyTasksDto.PremisesId);

            _context.PremisesTask.Add(propTask);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateContractor(PropertyDto propertyDto)
        {
            var property = await _premisesTask.GetPremiseTaskByIdAsync(propertyDto.Id);
            _mapper.Map(propertyDto, property);

            _premisesTask.Update(property);

            if (await _premisesTask.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to update property");
        }
    }
}
