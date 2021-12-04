using AutoMapper;
using FacilitiesManagementAPI.Data;
using FacilitiesManagementAPI.DTOs;
using FacilitiesManagementAPI.Entities;
using FacilitiesManagementAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacilitiesManagementAPI.Controllers
{
    public class PremiseContractorController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IPremiseContractorRepository _premiseContractor;
        private readonly IMapper _mapper;

        public PremiseContractorController(DataContext context, IPremiseContractorRepository premiseContractor, IMapper mapper)
        {
            _context = context;
            _premiseContractor = premiseContractor;
            _mapper = mapper;
        }

        [HttpPost("ConPrem")]
        public async Task<ActionResult<PremisesContractor>> CreateConPremLink(ContPremiseLinkDto conPremLink)
        {
            var conPrem = _mapper.Map<PremisesContractor>(conPremLink);
            _context.PremisesContractors.Add(conPrem);
            await _premiseContractor.SaveAllAsync(); 
            return Ok(conPremLink);
        }
       
        [HttpDelete("removelink/{propId},{conId}")]
        public async Task<ActionResult> RemoveContractorPremiseLink(Guid propId, Guid conId)
        {
            IEnumerable<PremisesContractor> pc = await _context.Set<PremisesContractor>()
                .Include(x => x.Contractor)
                .Include(x => x.Premises)
                .Where(x => x.ContractorId == conId && x.PremisesId == propId)
                .ToListAsync();

            PremisesContractor premisesContractor = pc.SingleOrDefault(x => x.ContractorId == conId && x.PremisesId == propId);

            if(premisesContractor != null)
            {
                _context.Remove(premisesContractor);
                if (await _premiseContractor.SaveAllAsync()) return Ok();
            }

            return BadRequest("Failed to remove");
        }
    }
}
