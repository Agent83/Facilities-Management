namespace FacilitiesManagementAPI.Entities.PremisesJobs
{
    public class PremisesJob
    {
        public int Id { get; set; }
        public string Descripiton { get; set; }
        public int? NoteId { get; set; }
        public int? PropertyId { get; set; }
        public bool IsDeleted { get; set; }
    }
}