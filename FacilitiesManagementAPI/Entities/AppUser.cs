using System;
using System.Collections.Generic;
using FacilitiesManagementAPI.Extensions;

namespace FacilitiesManagementAPI.Entities
{
    public class AppUser
    {
        public int  Id { get; set; }
        public string Username { get; set; } 
        public byte[] PasswordHash {get;set;}
        public byte[] PasswordSalt { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public string KnownAs { get; set; }
        public DateTime LastActive { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }

    }
}