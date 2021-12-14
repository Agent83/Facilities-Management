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
    public class AccountantRepository : IAccountantRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public AccountantRepository(DataContext context,IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }
  
        public async Task<Accountant> GetAccountantById(Guid Id)
        {
            return await _context.Accountant.FindAsync(Id);
        }

        public async Task<IEnumerable<Accountant>> GetAccountants()
        {
            return await _context.Accountant.ToListAsync();
        }

        public async Task<IEnumerable<PropAccountantDto>> GetAccountantsAsync()
        {
           return await _context.Accountant
                .ProjectTo<PropAccountantDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<PropAccountantDto> GetPropAccountantByIDAsync(Guid Id)
        {
            return await _context.Accountant
                .Where(x => x.Id == Id)
                .ProjectTo<PropAccountantDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public void Update(Accountant accountant)
        {
            _context.Entry(accountant).State = EntityState.Modified;
        }
    }
}
