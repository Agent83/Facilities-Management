using AutoMapper;
using FacilitiesManagementAPI.Entities;
using FacilitiesManagementAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FacilitiesManagementAPI.Data
{
    public class PremiseContractorRepository : IPremiseContractorRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PremiseContractorRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public  IQueryable<PremisesContractor> DeleteLinkFromTable(Guid premId, Guid conId)
        {
            return _context.PremisesContractors.
                FromSqlInterpolated($"DELETE FROM PremisesContractor WHERE PremisesId = {premId} AND ContractorId = {conId}");
                
        }

    }
}
