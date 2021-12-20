using AutoMapper;
using AutoMapper.QueryableExtensions;
using FacilitiesManagementAPI.DTOs;
using FacilitiesManagementAPI.Entities;
using FacilitiesManagementAPI.Helpers;
using FacilitiesManagementAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacilitiesManagementAPI.Data
{
    public class PremiseRepository : IPremiseRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PremiseRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Premises> GetPremiseByIdAsync(Guid Id)
        {
            return await _context.Premises.FindAsync(Id);
        }

        public async Task<Premises> GetPremByIdAsync(Guid Id)
        {
            return await _context.Premises
                .Include(x => x.PremisesTasks)
                .Include(x => x.Notes)
                .Include(x => x.Accountant.Id == x.AccountantId)
                .SingleAsync(x  => x.Id == Id);
        }

        public async Task<IEnumerable<Premises>> GetPremisesAsync()
        {
            return await _context.Premises.ToListAsync();
        }

        public async Task<IEnumerable<Premises>> GetPremWithAccAsync(Guid Id)
        {
            return await _context.Premises
                .Where(x => x.AccountantId == Id)
                .ToListAsync();
        }

        public async Task<PagedList<PropertyDto>> GetPropertiesAsync(PageListParams propertyParams)
        {
            var query = _context.Premises.AsQueryable();

            query = query.Where(x => x.IsArchieved == false)
                .Include(x => x.PremisesTasks)
                .OrderByDescending(x => x.PremisesTasks.First().CompletionDate); ;
                            
            return await PagedList<PropertyDto>.CreateAsync(query.ProjectTo<PropertyDto>
                (_mapper.ConfigurationProvider).AsNoTracking(), 
                propertyParams.PageNumber, propertyParams.PageSize);
                
        }

        public async Task<PropertyDto> GetPropertyByIdAsync(Guid Id)
        {
            return await _context.Premises
                .Where(x => x.Id == Id)
                .Include(x => x.Accountant)
                .ProjectTo<PropertyDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<PropertyDto> GetPropertyContractorLink(Guid id)
        {
            return await _context.Premises
                .Where(x => x.Id == id)
                .Include(x => x.Contractors)
                .ProjectTo<PropertyDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Premises premise)
        {
            _context.Entry(premise).State = EntityState.Modified;
        }
    }
}
