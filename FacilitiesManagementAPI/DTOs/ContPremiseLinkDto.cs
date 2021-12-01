using FacilitiesManagementAPI.Entities;
using System;

namespace FacilitiesManagementAPI.DTOs
{
    public class ContPremiseLinkDto
    {
        public Guid PremisesId { get; set; }
        public Guid ContractorId { get; set; }
    }
}
