using System;

namespace FacilitiesManagementAPI.Entities.PremisesCertificate
{
    public class PremesisCertificate
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime? DateAssessed { get; set; }
        public DateTime? DatePassed { get; set; }
        public DateTime? ExpireDate { get; set; }
        public DateTime? ReminderDate { get; set; }
        public bool Pass { get; set; }
        public int? PromesisId { get; set; }
    }
}