using FacilitiesManagementAPI.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FacilitiesManagementAPI.DTOs
{
    public class CreatePropertyDto
    {
        public string PremiseName { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string Email { get; set; }
        public int PremisesAddressId {  get; set; }
        public string AddressLine1 {  get; set; }
        public string AddressLine2 {  get; set;}
        public string City {  get; set; } //change to citytown 
        public string PostCode {  get; set; } //chnage to lowercase in code

    }
}
