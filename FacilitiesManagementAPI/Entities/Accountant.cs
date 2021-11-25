using System;
using System.Collections.Generic;

namespace FacilitiesManagementAPI.Entities
{
    public class Accountant
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<Premises> Premises { get; set; }
    }
}
