namespace FacilitiesManagementAPI.Entities
{
    public class PremisesJob
    {
        public int Id { get; set; }
        public string Descripiton { get; set; }
        public int? NoteId { get; set; }
        public int? PropertyId { get; set; }
        public bool IsDeleted { get; set; }
        
        public Premises Premises { get; set; }
        public int PremisesId { get; set; }
    }
}