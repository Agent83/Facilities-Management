using FacilitiesManagementAPI.DTOs;
using FacilitiesManagementAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FacilitiesManagementAPI.Interfaces
{
    public interface IContractorRepository
    {
        void Update(Contractor user);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<Contractor>> GetContractAsync();
        Task<Contractor> GetContractByIdAsync(int Id);
        Task<IEnumerable<ContractorDto>> GetContractorsAsync();
        Task<ContractorDto> GetContractorByIdAsync(int id);
    }
}
