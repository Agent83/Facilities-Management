using System;

namespace FacilitiesManagementAPI.Entities
{
    public class ContractorType
    {
        public int Id { get; set; }
        public string TypeDescription {  get; set; }
        public bool IsDeleted { get; set; }
    }
}
