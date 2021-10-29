using AutoMapper;
using FacilitiesManagementAPI.Entities;
using FacilitiesManagementAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public async Task<Accountant> GetAccountantByIdAsync(Guid Id)
        {
            return await _context.Accountant.FindAsync(Id);
        }

        public async Task<IEnumerable<Accountant>> GetAccountants()
        {
            return await _context.Accountant.ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Accountant accountant)
        {
            _context.Entry(accountant).State = EntityState.Modified;
        }
    }
}
