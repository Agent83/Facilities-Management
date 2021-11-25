using System;

namespace FacilitiesManagementAPI.DTOs
{
    public class PropAccountantDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid PremisesId { get; set; }
    }
}
