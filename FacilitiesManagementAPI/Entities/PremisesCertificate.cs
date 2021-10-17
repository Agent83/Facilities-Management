using System;

namespace FacilitiesManagementAPI.Entities
{
    public class PremisesCertificate
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime? DateAssessed { get; set; }
        public DateTime? DatePassed { get; set; }
        public DateTime? ExpireDate { get; set; }
        public DateTime? ReminderDate { get; set; }
        public bool Pass { get; set; }
        public bool IsDeleted { get; set; }
        public Premises Premises { get; set; }
        public int PremisesId { get; set; }
    }
}