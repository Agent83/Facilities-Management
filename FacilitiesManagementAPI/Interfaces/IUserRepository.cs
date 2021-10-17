using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FacilitiesManagementAPI.DTOs;
using FacilitiesManagementAPI.Entities;

namespace FacilitiesManagementAPI.Interfaces
{
    public interface IUserRepository
    {
        void Update(AppUser user);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<AppUser>> GetUsersAsync();
        Task<AppUser> GetUserByIdAsync(Guid Id);
        Task<AppUser> GetUserByUserNameAsync(string username);
        Task<IEnumerable<MemberDto>> GetMembersAsync();
        Task<MemberDto> GetMemberAsync(string username);
    }
}