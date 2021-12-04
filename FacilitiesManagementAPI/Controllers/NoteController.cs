using AutoMapper;
using FacilitiesManagementAPI.Data;
using FacilitiesManagementAPI.DTOs;
using FacilitiesManagementAPI.Entities;
using FacilitiesManagementAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FacilitiesManagementAPI.Controllers
{
    public class NoteController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly INoteRepository _note;
        private readonly DataContext _context;

        public NoteController(IMapper mapper, INoteRepository note, DataContext context )
        {
            _mapper = mapper;
            _note = note;
            _context = context;
        }
       [HttpGet]
       public async Task<ActionResult<IEnumerable<Note>>> GetNotesAsync()
       {
            var notes = await _note.GetNotesAsync();
            return Ok(notes);
       }
        public async Task<ActionResult<Note>> GetNoteByIdAsync(Guid Id)
        {
            return await _note.GetNoteByIdAsync(Id);
        }
        public async Task<ActionResult<IEnumerable<NoteDto>>> GetNotesDtoAsync()
        {
            var notes = await _note.GetNotesDtoAsync();
            return Ok(notes);
        }
        public async Task<ActionResult<NoteDto>> GetNoteDtoByIdAsync(Guid Id)
        {
            return await _note.GetNoteDtoByIdAsync(Id);
        }

        [HttpPost("createNote")]
        public async Task<ActionResult<NoteDto>> CreateContractor(CreateNoteDto noteDto)
        {
            var note = _mapper.Map<Note>(noteDto);

            _context.Note.Add(note);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateContractor(NoteDto noteDto)
        {
            var note = await _note.GetNoteByIdAsync(noteDto.Id);
            _mapper.Map(noteDto, note);

            _note.Update(note);

            if (await _note.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to update property");
        }
    }
}

