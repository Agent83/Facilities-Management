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
    public class ContractorTypeController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IContractorTypeRepository _contractor;

        public ContractorTypeController(DataContext context, IContractorTypeRepository contractor)
        {
            _context = context;
            _contractor = contractor;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContractorType>>> GetContractorTypeAsync()
        {
            var contractorType = await _contractor.GetContractorTypes();
            return Ok(contractorType);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContractorType>> GetContractorTypeById(Guid Id)
        {
            return await _contractor.GetContractorTypeByIdAsync(Id);
        }

        [HttpPost("createConType")]
        public async Task<ActionResult<ContractorType>> CreateContactorType(ContractorType contractorType)
        {
           _context.ContractorTypes.Add(contractorType);
            await _contractor.SaveAllAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateContactorType(ContractorType contractorType)
        {
            _contractor.Update(contractorType);

            if(await _contractor.SaveAllAsync()) return NoContent();
            return BadRequest("Failed to update contractor type");
        }
    }
}
