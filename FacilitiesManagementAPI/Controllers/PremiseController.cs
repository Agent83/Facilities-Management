﻿using AutoMapper;
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
        public PremiseController(IMapper mapper, IPremiseRepository premise)
        {
            _mapper = mapper;
            _premise = premise;
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
    
    }
}
