﻿using FacilitiesManagementAPI.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FacilitiesManagementAPI.DTOs
{
    public class PropertyDto
    {
        public int Id { get; set; }
        public string PremiseName { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; } 
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string Email { get; set; }
        public PremisesAddress PremisesAddress {  get; set; }
        public ICollection<Note> Notes { get; set; }
        public ICollection<PremisesTask> PremisesTasks { get; set; }

    }
}