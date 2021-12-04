using AutoMapper;
using FacilitiesManagementAPI.Data;
using FacilitiesManagementAPI.DTOs;
using FacilitiesManagementAPI.Entities;
using FacilitiesManagementAPI.Extensions;
using FacilitiesManagementAPI.Helpers;
using FacilitiesManagementAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<ActionResult<IEnumerable<PropertyDto>>> GetPremises([FromQuery]PageListParams propListParams)
        {
            var premises = await _premise.GetPropertiesAsync(propListParams);

            Response.AddPaginationHeader(premises.CurrentPage, premises.PageSize,
                premises.TotalCount, premises.TotalPages);
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


        [HttpGet("removeaccountant/{id}")]
        public async Task<ActionResult> RemoveAccountant(Guid id)
        {
            var premise = await _premise.GetPremiseByIdAsync(id);
            premise.AccountantId = null;
            if(await _premise.SaveAllAsync()) return Ok();
            return BadRequest("Could not remove accountant");
            
        }

        [HttpDelete("deltasks/{propId},{taskId}")]
        public async Task<ActionResult> DelTasks(Guid propId, Guid taskId)
        {
            var premise = await _premise.GetPremByIdAsync(propId);
            var premTaskToRemove = premise.PremisesTasks
                .Single(x => x.Id==taskId);
 
            premise.PremisesTasks.Remove(premTaskToRemove);

            if (await _premise.SaveAllAsync()) return Ok();

            return BadRequest("Failed to delete task");
         }

        [HttpDelete("delnote/{propId},{noteId}")]
        public async Task<ActionResult> DeleteNote(Guid propId, Guid noteId)
        {
            var premise = await _premise.GetPremByIdAsync(propId);
            var noteToRemove = premise.Notes
                .Single(x => x.Id == noteId);

            premise.Notes.Remove(noteToRemove);

            if (await _premise.SaveAllAsync()) return Ok();

            return BadRequest("Failed to remove");
        }
    }
}
