using System;
using System.Collections.Generic;

namespace FacilitiesManagementAPI.Entities
{
    public class Premises
    {
        public int Id { get; set; }
        public string PremiseName { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string Email { get; set; }
        public virtual PremisesAddress PremisesAddress { get; set; }
        public ICollection<Note> Notes {get;set;}
        public ICollection<PremisesTask> PremisesTasks {get; set;}
    
    }
}