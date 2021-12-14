using FacilitiesManagementAPI.DTOs;
using FacilitiesManagementAPI.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FacilitiesManagementAPI.Interfaces
{
    public interface IPremisesTaskRepository
    {
        void Update(PremisesTask user);
        Task<IEnumerable<PremisesTask>> GetPremiseTaskAsync();
        Task<PremisesTask> GetPremiseTaskByIdAsync(Guid Id);
        Task<IEnumerable<PropertyTasksDto>> GetTasks();
        Task<PropertyTasksDto> GetPropertyTaskByIdAsync(Guid id);
    }
}
