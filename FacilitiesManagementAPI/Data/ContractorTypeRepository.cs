using AutoMapper;
using FacilitiesManagementAPI.Entities;
using FacilitiesManagementAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FacilitiesManagementAPI.Data
{
    public class ContractorTypeRepository : IContractorTypeRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ContractorTypeRepository(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        

        public async Task<IEnumerable<ContractorType>> GetContractorTypes()
        {
            return await _context.ContractorTypes.ToListAsync();
        }

        public async Task<ContractorType> GetContractorTypeByIdAsync(Guid Id)
        {
            return await _context.ContractorTypes.FindAsync(Id);
        }

        public void Update(ContractorType contractor)
        {
            _context.Entry(contractor).State = EntityState.Modified;
        }
    }
}
