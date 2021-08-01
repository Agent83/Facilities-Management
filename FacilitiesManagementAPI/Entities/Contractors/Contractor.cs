namespace FacilitiesManagementAPI.Entities.Contractors
{
    public class Contractor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Rating { get; set; }
        public int PremisesId { get; set; }
        public int? ContractorTypeId { get; set; }

    }
}