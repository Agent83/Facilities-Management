using AutoMapper;
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

        public NoteController(IMapper mapper, INoteRepository note)
        {
            _mapper = mapper;
            _note = note;
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
    }
}
