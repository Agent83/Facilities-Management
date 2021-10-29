using FacilitiesManagementAPI.Entities;
using System.Threading.Tasks; 
using System.Collections.Generic;
using System;

namespace FacilitiesManagementAPI.Interfaces
{
    public interface IAccountantRepository
    {
        void Update(Accountant accountant);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<Accountant>> GetAccountants();
        Task<Accountant> GetAccountantByIdAsync(Guid Id);
        //Task<IEnumerable<AccountantDto>>
    }
}
