using AutoMapper;
using FacilitiesManagementAPI.Data;
using FacilitiesManagementAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections;
using FacilitiesManagementAPI.Entities;
using System.Collections.Generic;
using System;
using FacilitiesManagementAPI.DTOs;

namespace FacilitiesManagementAPI.Controllers
{
    public class PropAccountantController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly DataContext _context;

        public PropAccountantController(IMapper mapper,IUnitOfWork unitOfWork, DataContext context)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Accountant>>> GetAccountantsAsync()
        {
            var accountants = await _unitOfWork.AccountantRepository.GetAccountants();
            return Ok(accountants);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Accountant>> GetAccountsAsync(Guid Id)
        {
            return await _unitOfWork.AccountantRepository.GetAccountantById(Id);
        }

        [HttpPost("accountant")]
        public async Task<ActionResult<Accountant>> CreateAccountant(CreateAccountantDto accountant)
        {
            var premAccountant = _mapper.Map<Accountant>(accountant);
            _context.Accountant.Add(premAccountant);
            await _unitOfWork.Complete();

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAccountant(PropAccountantDto propAccountant)
        {
            var accountant  = await _unitOfWork.AccountantRepository.GetAccountantById(propAccountant.Id);
            _mapper.Map(propAccountant, accountant);

            _unitOfWork.AccountantRepository.Update(accountant);
            if (await _unitOfWork.Complete()) return NoContent();

            return BadRequest("Failed to update accountant"); ;
        }
    }
}
