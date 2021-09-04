using System;
using System.Collections;
using System.Collections.Generic;

namespace FacilitiesManagementAPI.Entities
{
    public class Contractor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Rating { get; set; }
        public int PremisesId { get; set; }
        public int? ContractorTypeId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;

        public ICollection<Note> Notes { get; set; }
        public ICollection<PremisesJob> Jobs { get; set; }

    }
}