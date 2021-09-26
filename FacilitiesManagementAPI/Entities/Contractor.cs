using System;
using System.Collections;
using System.Collections.Generic;

namespace FacilitiesManagementAPI.Entities
{
    public class Contractor
    {
        public int Id { get; set; }
        public string BusinessName { get; set;  }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PremisesId { get; set; }
        public int? ContractorTypeId { get; set; }
        public int GreenLightId { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;

        public ICollection<Note> Notes { get; set; }
        public ICollection<PremisesTask> Jobs { get; set; }

    }
}