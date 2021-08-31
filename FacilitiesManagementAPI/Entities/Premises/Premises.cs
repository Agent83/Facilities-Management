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
        public ICollection<Note> Notes {get;set;}
        public ICollection<PremisesJob> Jobs {get; set;}
        public ICollection<PremisesContactManager> ContactManagers { get; set; }
        public ICollection<PremisesCertificate> PremiseCerts { get; set; }
    
    }
}