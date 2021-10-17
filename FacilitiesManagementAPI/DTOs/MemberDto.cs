using System;
using System.Collections.Generic;

namespace FacilitiesManagementAPI.DTOs
{
    public class MemberDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } 
        public string PhotoUrl { get; set; }
        public int Age { get; set; }
        public DateTime Created { get; set; }
        public string KnownAs { get; set; }
        public DateTime LastActive { get; set; } 
        public bool IsDeleted { get; set; }
    }
}