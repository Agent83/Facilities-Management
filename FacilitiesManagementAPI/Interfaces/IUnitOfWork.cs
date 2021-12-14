using System.Threading.Tasks;

namespace FacilitiesManagementAPI.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IPremiseRepository PremiseRepository { get; } 
        IPremiseContractorRepository PremiseContractorRepository { get; }  
        IPremisesTaskRepository PremisesTaskRepository { get; }
        INoteRepository NoteRepository { get; }
        IAccountantRepository AccountantRepository { get; }
        IContractorRepository ContractorRepository { get; }
        IContractorTypeRepository ContractorTypeRepository { get; }

        Task<bool> Complete();
        bool HasChanges();
    }
}
