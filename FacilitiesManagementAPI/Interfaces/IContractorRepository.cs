using FacilitiesManagementAPI.DTOs;
using FacilitiesManagementAPI.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FacilitiesManagementAPI.Interfaces
{
    public interface IContractorRepository
    {
        void Update(Contractor contractor);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<Contractor>> GetContractAsync();
        Task<Contractor> GetContractByIdAsync(Guid Id);
        Task<IEnumerable<ContractorDto>> GetContractorsAsync();
        Task<ContractorDto> GetContractorByIdAsync(Guid id);
    }
}
