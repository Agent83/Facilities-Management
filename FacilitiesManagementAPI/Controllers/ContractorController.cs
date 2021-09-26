using AutoMapper;
using FacilitiesManagementAPI.DTOs;
using FacilitiesManagementAPI.Entities;
using FacilitiesManagementAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FacilitiesManagementAPI.Controllers
{
    public class ContractorController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IContractor _contractor;

        public ContractorController(IMapper mapper, IContractor contractor)
        {
            _mapper = mapper;
            _contractor = contractor;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContractorDto>>> GetContractors()
        {
           var contractors = await _contractor.GetContractorsAsync();
            return Ok(contractors);
        }

        [HttpGet("id")]
        public async Task <ActionResult<ContractorDto>> GetContractorById(int id)
        {
            return await _contractor.GetContractorByIdAsync(id);
        }
    }
}
