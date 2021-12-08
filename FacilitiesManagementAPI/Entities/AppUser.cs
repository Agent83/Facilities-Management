using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace FacilitiesManagementAPI.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
       
        public DateTime Created { get; set; } = DateTime.Now;
        public string KnownAs { get; set; }
        public DateTime LastActive { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }


    }
}