using System;

namespace FacilitiesManagementAPI.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public string NoteContent { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        
    }
}