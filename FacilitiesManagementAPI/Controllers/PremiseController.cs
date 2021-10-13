using AutoMapper;
using FacilitiesManagementAPI.Data;
using FacilitiesManagementAPI.DTOs;
using FacilitiesManagementAPI.Entities;
using FacilitiesManagementAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FacilitiesManagementAPI.Controllers
{
    public class PremiseController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IPremiseRepository _premise;
        private readonly DataContext _context;

        public PremiseController(IMapper mapper, IPremiseRepository premise,DataContext context)
        {
            _mapper = mapper;
            _premise = premise;
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PropertyDto>>> GetPremises()
        {
            var premises = await _premise.GetPropertiesAsync();
            return Ok(premises);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyDto>> GetProperty(int id)
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
    }
}
