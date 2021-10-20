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
    public class ContractorController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IContractorRepository _contractor;
        private readonly DataContext _context;

        public ContractorController(IMapper mapper, IContractorRepository contractor, DataContext context)
        {
            _mapper = mapper;
            _contractor = contractor;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContractorDto>>> GetContractors()
        {
           var contractors = await _contractor.GetContractorsAsync();
            return Ok(contractors);
        }

        [HttpGet("{id}")]
        public async Task <ActionResult<ContractorDto>> GetContractorById(Guid id)
        {
            return await _contractor.GetContractorByIdAsync(id);
        }

        [HttpPost("createcon")]
        public async Task<ActionResult<ContractorDto>> CreateContractor(CreateContractorDto contractorDto)
        {
            var contractor = _mapper.Map<Contractor>(contractorDto);

            _context.Contractors.Add(contractor);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateContractor(UpdateContractorDto contractorDto)
        {
            var contractor = await _contractor.GetContractByIdAsync(contractorDto.Id);
            _mapper.Map(contractorDto, contractor);

            _contractor.Update(contractor);

            if (await _contractor.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to update property");
        }
    }
}
