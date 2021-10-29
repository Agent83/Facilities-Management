using AutoMapper;
using FacilitiesManagementAPI.Data;
using FacilitiesManagementAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections;
using FacilitiesManagementAPI.Entities;
using System.Collections.Generic;
using System;

namespace FacilitiesManagementAPI.Controllers
{
    public class PropAccountantController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IAccountantRepository _accountant;
        private readonly DataContext _context;

        public PropAccountantController(IMapper mapper, IAccountantRepository accountant, DataContext context)
        {
            _mapper = mapper;
            _accountant = accountant;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Accountant>>> GetAccountantsAsync()
        {
            var accountants = await _accountant.GetAccountants();
            return Ok(accountants);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Accountant>> GetAccountsAsync(Guid Id)
        {
            return await _accountant.GetAccountantByIdAsync(Id);
        }

        [HttpPost("accountant")]
        public async Task<ActionResult<Accountant>> CreateAccountant(Accountant accountant)
        {
            _context.Accountant.Add(accountant);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAccountant(Accountant accountant)
        {
            _accountant.Update(accountant);
            if (await _accountant.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to update accountant"); ;
        }
    }
}
