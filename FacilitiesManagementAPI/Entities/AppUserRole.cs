using Microsoft.AspNetCore.Identity;
using System;

namespace FacilitiesManagementAPI.Entities
{
    public class AppUserRole : IdentityUserRole<Guid>
    {
        public AppUser User { get; set; }
        public AppRole Role { get; set; }

    }   
}
