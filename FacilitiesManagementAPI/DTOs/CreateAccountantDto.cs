using System;

namespace FacilitiesManagementAPI.DTOs
{
    public class CreateAccountantDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid PremisesId { get; set; }
    }
}
