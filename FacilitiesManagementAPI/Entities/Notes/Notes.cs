namespace FacilitiesManagementAPI.Entities.Notes
{
    public class Notes
    {
        public int Id { get; set; }
        public string NoteContent { get; set; }
        public int? ContractorId { get; set; }
        public int? PremisesId { get; set; }
        public int?  CertificatedId { get; set; }
    }
}