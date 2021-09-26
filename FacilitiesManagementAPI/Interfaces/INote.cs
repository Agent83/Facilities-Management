using FacilitiesManagementAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FacilitiesManagementAPI.Interfaces
{
    public interface INote
    {
        void Update(Note user);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<Note>> GetNotesAsync();
        Task<Note> GetNoteByIdAsync(int Id);
        //Task<IEnumerable<ContractorDto>> GetContractorsAsync();
        //Task<ContractorDto> GetContractorByIdAsync(int id);
    }
}
