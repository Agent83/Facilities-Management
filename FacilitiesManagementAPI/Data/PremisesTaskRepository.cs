using AutoMapper;
using AutoMapper.QueryableExtensions;
using FacilitiesManagementAPI.DTOs;
using FacilitiesManagementAPI.Entities;
using FacilitiesManagementAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacilitiesManagementAPI.Data
{
    public class PremisesTaskRepository : IPremisesTaskRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PremisesTaskRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PremisesTask>> GetPremiseTaskAsync()
        {
            return await _context.PremisesTask.ToListAsync();
        }

        public async Task<PremisesTask> GetPremiseTaskByIdAsync(Guid Id)
        {
           return await _context.PremisesTask.FindAsync(Id);
        }

        public async Task<PropertyTasksDto> GetPropertyTaskByIdAsync(Guid id)
        {
            return await _context.PremisesTask
                .Where(x => x.Id == id)
                .ProjectTo<PropertyTasksDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<PropertyTasksDto>> GetTasks()
        {
            return await _context.PremisesTask
                .ProjectTo<PropertyTasksDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }


        public void Update(PremisesTask premTask)
        {
            _context.Entry(premTask).State = EntityState.Modified;

        }
    }
}
