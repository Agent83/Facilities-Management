using FacilitiesManagementAPI.Entities;
using System;

namespace FacilitiesManagementAPI.DTOs
{
    public class UpdatePremiseDto
    {
        public Guid Id {  get; set; }
        public string PremiseNumber { get; set; }
        public string PremiseName { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string Email { get; set; }
        public Guid AccountantId { get; set; } 
        public PremisesAddress PremisesAddress { get; set; }
    }
}
