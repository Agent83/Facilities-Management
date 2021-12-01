using System.Threading.Tasks;

namespace FacilitiesManagementAPI.Interfaces
{
    public interface IPremiseContractorRepository
    {
        Task<bool> SaveAllAsync();
    }
}
