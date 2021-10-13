using FacilitiesManagementAPI.Entities;
using System;
using System.Collections.Generic;

namespace FacilitiesManagementAPI.DTOs
{
    public class ContractorDto
    {
        public int Id {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Rating { get; set; }
        public int? ContractorTypeId { get; set; }
        public string GreenLightEnum { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }


        public ICollection<Note> Notes { get; set; }
        public ICollection<PremisesTask> Jobs { get; set; }
    }
}
