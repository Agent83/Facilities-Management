using System;

namespace FacilitiesManagementAPI.DTOs
{
    public class PropertyTasksDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime CompletionDate { get; set; }
        public string Description { get; set; }
        public int? NoteId { get; set; }
        public bool IsDeleted { get; set; }

        public int PremisesId { get; set; }
    }
}
