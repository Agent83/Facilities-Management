using System;

namespace FacilitiesManagementAPI.Entities
{
    public class Note
    {
        public Guid Id { get; set; }
        public string NoteContent { get; set; }
        public bool IsPerm { get; set; }
        public bool IsDeleted { get; set; }
        public Guid PremisesId { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        
    }
}