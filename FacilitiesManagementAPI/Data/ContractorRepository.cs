using AutoMapper;
using AutoMapper.QueryableExtensions;
using FacilitiesManagementAPI.DTOs;
using FacilitiesManagementAPI.Entities;
using FacilitiesManagementAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacilitiesManagementAPI.Data
{
    public class ContractorRepository : IContractorRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ContractorRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Contractor>> GetContractAsync()
        {
            return await _context.Contractors.ToListAsync();
        }

        public async Task<Contractor> GetContractByIdAsync(Guid Id)
        {
            return await _context.Contractors.FindAsync(Id);
        }

        public async Task<ContractorDto> GetContractorByIdAsync(Guid id)
        {
           return await _context.Contractors
                .Where(x => x.Id == id)
                .ProjectTo<ContractorDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<ContractorDto>> GetContractorsAsync()
        {
            return await _context.Contractors
                .ProjectTo<ContractorDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public void Update(Contractor contractor)
        {
            _context.Entry(contractor).State = EntityState.Modified;
        }

        public void DeleteContractor(Contractor contractor)
        {
            _context.Contractors.Remove(contractor);
        }
    }
}
