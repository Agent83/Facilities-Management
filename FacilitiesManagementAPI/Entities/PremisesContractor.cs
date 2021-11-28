using System;

namespace FacilitiesManagementAPI.Entities
{
    public class PremisesContractor
    {
        public Guid PremisesId { get; set; }
        public Guid ContractorId { get; set; }
        public Premises Premises { get; set; }
        public Contractor Contractor { get; set; }
        public bool IsDeleted { get; set; }
    }
}
