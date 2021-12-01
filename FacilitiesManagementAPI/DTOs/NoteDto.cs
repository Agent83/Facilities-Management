using FacilitiesManagementAPI.Entities;
using System;

namespace FacilitiesManagementAPI.DTOs
{
    public class NoteDto
    {
        public Guid Id { get; set; }
        public string NoteContent { get; set; }
        public DateTime DateCreated { get; set; } 
        public bool IsPerm { get; set; }
        public Guid PremisesId { get; set; }
        public Guid ContractorId { get; set; }
    }
}
