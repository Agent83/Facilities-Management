using FacilitiesManagementAPI.DTOs;
using FacilitiesManagementAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FacilitiesManagementAPI.Interfaces
{
    public interface INoteRepository
    {
        void Update(Note user);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<Note>> GetNotesAsync();
        Task<Note> GetNoteByIdAsync(int Id);
        Task<IEnumerable<NoteDto>> GetNotesDtoAsync();
        Task<NoteDto> GetNoteDtoByIdAsync(int id);
    }
}
