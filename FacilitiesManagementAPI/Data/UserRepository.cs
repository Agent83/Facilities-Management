using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FacilitiesManagementAPI.DTOs;
using FacilitiesManagementAPI.Entities;
using FacilitiesManagementAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FacilitiesManagementAPI.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UserRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await _context.Users
            .Include(p => p.Photos)
            .ToListAsync();
        }

        public async Task<AppUser> GetUserByIdAsync(int Id)
        {
            return await _context.Users.FindAsync(Id);
        }

        public async Task<AppUser> GetUserByUserNameAsync(string username)
        {
            return await _context.Users
            .Include(p => p.Photos)
            .SingleOrDefaultAsync(x => x.Username == username);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(AppUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        public async Task<IEnumerable<MemberDto>> GetMembersAsync()
        {
            return await _context.Users
                        .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                        .ToListAsync();
        }

        public async Task<MemberDto> GetMemberAsync(string username)
        {
            return await _context.Users
            .Where(x => x.Username == username)
            .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
        }
    }
}