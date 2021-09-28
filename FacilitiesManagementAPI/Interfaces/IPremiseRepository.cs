using FacilitiesManagementAPI.DTOs;
using FacilitiesManagementAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FacilitiesManagementAPI.Interfaces
{
    public interface IPremiseRepository
    {
        void Update(Premises premise);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<Premises>> GetPremisesAsync();
        Task<Premises> GetPremiseByIdAsync(int Id);
        Task<IEnumerable<PropertyDto>> GetPropertiesAsync();
        Task<PropertyDto> GetPropertyByIdAsync(int id);
    }
}
