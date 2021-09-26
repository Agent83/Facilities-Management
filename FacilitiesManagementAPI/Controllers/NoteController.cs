using AutoMapper;
using FacilitiesManagementAPI.Entities;
using FacilitiesManagementAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FacilitiesManagementAPI.Controllers
{
    public class NoteController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly INote _note;

        public NoteController(IMapper mapper, INote note)
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
        public async Task<ActionResult<Note>> GetNoteByIdAsync(int Id)
        {
            return await _note.GetNoteByIdAsync(Id);
        }
    }
}
