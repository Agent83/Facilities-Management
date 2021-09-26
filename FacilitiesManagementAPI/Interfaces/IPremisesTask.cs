using FacilitiesManagementAPI.DTOs;
using FacilitiesManagementAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FacilitiesManagementAPI.Interfaces
{
    public interface IPremisesTask
    {
        void Update(PremisesTask user);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<PremisesTask>> GetPremiseTaskAsync();
        Task<PremisesTask> GetPremiseTaskByIdAsync(int Id);
        Task<IEnumerable<PropertyTasksDto>> GetTasks();
        Task<PropertyTasksDto> GetPropertyTaskByIdAsync(int id);
    }
}
