using AutoMapper;
using FacilitiesManagementAPI.Interfaces;
using System.Threading.Tasks;

namespace FacilitiesManagementAPI.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UnitOfWork(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IUserRepository UserRepository => new UserRepository(_context, _mapper);

        public IPremiseRepository PremiseRepository => new PremiseRepository(_context, _mapper);

        public IPremiseContractorRepository PremiseContractorRepository => new PremiseContractorRepository(_context, _mapper);

        public IPremisesTaskRepository PremisesTaskRepository => new PremisesTaskRepository(_context, _mapper);

        public INoteRepository NoteRepository => new NoteRepository(_context, _mapper);

        public IAccountantRepository AccountantRepository => new AccountantRepository(_context, _mapper);

        public IContractorRepository ContractorRepository => new ContractorRepository(_context, _mapper);

        public IContractorTypeRepository ContractorTypeRepository => new ContractorTypeRepository(_context, _mapper);

        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }
    }
}
