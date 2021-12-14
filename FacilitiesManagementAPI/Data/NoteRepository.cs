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
    public class NoteRepository : INoteRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public NoteRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Note> GetNoteByIdAsync(Guid Id)
        {
            return await _context.Note.FindAsync(Id);
        }

        public async Task<NoteDto> GetNoteDtoByIdAsync(Guid id)
        {
           return await _context.Note
                .Where(x => x.Id == id)
                .ProjectTo<NoteDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Note>> GetNotesAsync()
        {
            return await _context.Note.ToListAsync();
        }

        public async Task<IEnumerable<NoteDto>> GetNotesDtoAsync()
        {
           return await _context.Note
                .ProjectTo<NoteDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public void Update(Note note)
        {
            _context.Entry(note).State = EntityState.Modified;
        }
    }
}
