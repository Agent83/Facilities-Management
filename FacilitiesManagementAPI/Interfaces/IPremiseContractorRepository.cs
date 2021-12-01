using FacilitiesManagementAPI.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FacilitiesManagementAPI.Interfaces
{
    public interface IPremiseContractorRepository
    {
        Task<bool> SaveAllAsync();
        IQueryable<PremisesContractor> DeleteLinkFromTable(Guid premId, Guid conId);
    }
}
