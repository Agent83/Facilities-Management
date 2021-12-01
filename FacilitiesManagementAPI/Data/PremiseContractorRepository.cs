using AutoMapper;
using FacilitiesManagementAPI.Interfaces;
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
    }
}
