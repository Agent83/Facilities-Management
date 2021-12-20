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
        void DeleteAccountant(Accountant accountant);
        Task<IEnumerable<Accountant>> GetAccountants();
        Task<IEnumerable<PropAccountantDto>> GetAccountantsAsync();
        Task<Accountant> GetAccountantById(Guid Id);
        Task<PropAccountantDto> GetPropAccountantByIDAsync(Guid Id);
    }
}
