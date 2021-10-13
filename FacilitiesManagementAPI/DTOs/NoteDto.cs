using FacilitiesManagementAPI.Entities;
using System;

namespace FacilitiesManagementAPI.DTOs
{
    public class NoteDto
    {
        public int Id { get; set; }
        public string NoteContent { get; set; }
        public DateTime DateCreated { get; set; } 
        public int PremisesId { get; set; }
        public int ContractorId { get; set; }
        public int PremisesCertId { get; set; }
    }
}
