using AutoMapper;
using FacilitiesManagementAPI.Data;
using FacilitiesManagementAPI.DTOs;
using FacilitiesManagementAPI.Entities;
using FacilitiesManagementAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<PremisesContractor>> CreateConPremLink(CreateContPremiseLinkDto conPremLink)
        {
            var conPrem = _mapper.Map<PremisesContractor>(conPremLink);
            _context.PremisesContractors.Add(conPrem);
            await _premiseContractor.SaveAllAsync(); 
            return Ok(conPremLink);
        }
    }
}
