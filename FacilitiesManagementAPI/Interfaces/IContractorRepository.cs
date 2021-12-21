using FacilitiesManagementAPI.DTOs;
using FacilitiesManagementAPI.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FacilitiesManagementAPI.Interfaces
{
    public interface IContractorRepository
    {
        void DeleteContractor(Contractor contractor);
        void Update(Contractor contractor);
        Task<IEnumerable<Contractor>> GetContractAsync();
        Task<Contractor> GetContractByIdAsync(Guid Id);
        Task<PagedList<ContractorDto>> GetContractorsAsync(PageListParams pageListParams);
        Task<ContractorDto> GetContractorByIdAsync(Guid id);
    }
}
