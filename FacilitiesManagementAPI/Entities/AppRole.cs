using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace FacilitiesManagementAPI.Entities
{
    public class AppRole : IdentityRole<Guid>
    {
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}
