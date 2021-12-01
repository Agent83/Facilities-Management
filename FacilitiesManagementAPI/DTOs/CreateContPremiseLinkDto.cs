using FacilitiesManagementAPI.Entities;
using System;

namespace FacilitiesManagementAPI.DTOs
{
    public class CreateContPremiseLinkDto
    {
        public Guid PremisesId { get; set; }
        public Guid ContractorId { get; set; }
    }
}
