namespace FacilitiesManagementAPI.DTOs
{
    public class CreateContractorDto
    {
        public string BusinessName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Rating { get; set; }
        public int? ContractorTypeId { get; set; }
        public string GreenLightEnum { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string Email { get; set; }
    }
}
