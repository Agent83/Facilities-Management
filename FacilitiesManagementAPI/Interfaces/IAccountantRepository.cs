using FacilitiesManagementAPI.Entities;
using System.Threading.Tasks; 
using System.Collections.Generic;
using System;
using FacilitiesManagementAPI.DTOs;

namespace FacilitiesManagementAPI.Interfaces
{
    public interface IAccountantRepository
    {
        void Update(Accountant accountant);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<Accountant>> GetAccountants();
        Task<IEnumerable<PropAccountantDto>> GetAccountantsAsync();
        Task<Accountant> GetAccountantById(int Id);
        Task<PropAccountantDto> GetPropAccountantByIDAsync(int Id);
    }
}
