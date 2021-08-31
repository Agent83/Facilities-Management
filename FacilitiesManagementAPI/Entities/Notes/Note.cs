using System;

namespace FacilitiesManagementAPI.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public string NoteContent { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        
        public Premises Premises { get; set; }
        public int PremisesId { get; set; }

        public Contractor Contractor { get; set; }
        public int ContractorId { get; set; }
        public PremisesCertificate PremiseCert { get; set; }
        public int PremisesCertId { get; set; }
    }
}