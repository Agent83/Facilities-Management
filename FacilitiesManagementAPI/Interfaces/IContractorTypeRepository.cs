using FacilitiesManagementAPI.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FacilitiesManagementAPI.Interfaces
{
    public interface IContractorTypeRepository
    {
        void Update(ContractorType contractor);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<ContractorType>> GetContractorTypes();
        Task<ContractorType> GetContractorTypeByIdAsync(Guid Id);
    }
}
