using System;

namespace FacilitiesManagementAPI.DTOs
{
    public class CreateNoteDto
    {
        public string NoteContent { get; set; }
        public bool IsPerm { get; set; }
        public Guid PremisesId { get; set; }
        public Guid ContractorId { get; set; }
    }
}
