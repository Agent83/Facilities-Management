using FacilitiesManagementAPI.DTOs;
using FacilitiesManagementAPI.Entities;
using FacilitiesManagementAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FacilitiesManagementAPI.Interfaces
{
    public interface IPremiseRepository
    {
        Task<bool> SaveAllAsync();
        void Update(Premises premise);
        Task<IEnumerable<Premises>> GetPremisesAsync();
        Task<IEnumerable<Premises>> GetPremWithAccAsync(Guid Id);

        Task<Premises> GetPremiseByIdAsync(Guid Id);
        Task<PagedList<PropertyDto>> GetPropertiesAsync(PageListParams propertyParams);
        Task<PropertyDto> GetPropertyByIdAsync(Guid id);
        Task<PropertyDto> GetPropertyContractorLink(Guid id);
        Task<Premises> GetPremByIdAsync(Guid Id);
    }
}
