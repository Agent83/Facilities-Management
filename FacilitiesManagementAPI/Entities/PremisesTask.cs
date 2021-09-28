namespace FacilitiesManagementAPI.Entities
{
    public class PremisesTask
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int? NoteId { get; set; }
        public bool IsDeleted { get; set; }
        public int? PremisesId { get; set; }
    }
}