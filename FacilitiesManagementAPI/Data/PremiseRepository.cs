using AutoMapper;
using AutoMapper.QueryableExtensions;
using FacilitiesManagementAPI.DTOs;
using FacilitiesManagementAPI.Entities;
using FacilitiesManagementAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Premises> GetPremiseByIdAsync(int Id)
        {
            return await _context.Premises.FindAsync(Id);
        }

        public async Task<IEnumerable<Premises>> GetPremisesAsync()
        {
            return await _context.Premises.ToListAsync();
        }

        public async Task<IEnumerable<PropertyDto>> GetPropertiesAsync()
        {
            return await _context.Premises
                .ProjectTo<PropertyDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<PropertyDto> GetPropertyByIdAsync(int Id)
        {
            return await _context.Premises
                .Where(x => x.Id == Id)
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
