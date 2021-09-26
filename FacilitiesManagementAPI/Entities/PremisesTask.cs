namespace FacilitiesManagementAPI.Entities
{
    public class PremisesTask
    {
        public int Id { get; set; }
        public string Descripiton { get; set; }
        public int? NoteId { get; set; }
        public int? PropertyId { get; set; }
        public bool IsDeleted { get; set; }
        public int PremisesId { get; set; }
    }
}