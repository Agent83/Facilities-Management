using FacilitiesManagementAPI.DTOs;
using FacilitiesManagementAPI.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FacilitiesManagementAPI.Interfaces
{
    public interface IPremiseRepository
    {
        void Update(Premises premise);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<Premises>> GetPremisesAsync();
        Task<Premises> GetPremiseByIdAsync(Guid Id);
        Task<IEnumerable<PropertyDto>> GetPropertiesAsync();
        Task<PropertyDto> GetPropertyByIdAsync(Guid id);
        Task<PropertyDto> GetPropertyContractorLink(Guid id);
        Task<Premises> GetPremByIdAsync(Guid Id);
    }
}
