using System;

namespace FacilitiesManagementAPI.Entities
{
    public class PremisesTask
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime CompletionDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? NoteId { get; set; }
        public bool IsDeleted { get; set; }
        public Guid PremisesId { get; set; }
        public Premises Premises { get; set; }
    }
}