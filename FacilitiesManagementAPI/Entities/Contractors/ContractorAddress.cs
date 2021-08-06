namespace FacilitiesManagementAPI.Entities.Contractors
{
    public class ContractorAddress
    {
        public int Id { get; set; }
        public string BusinessName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
        public string  PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }    
         public bool IsDeleted { get; set; } 
    }
}