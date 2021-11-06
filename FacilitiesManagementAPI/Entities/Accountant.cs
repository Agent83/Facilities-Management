﻿using System;

namespace FacilitiesManagementAPI.Entities
{
    public class Accountant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid PremisesId { get; set; }
        public virtual Premises Premises { get; set; }
    }
}
