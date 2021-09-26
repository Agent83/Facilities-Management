namespace FacilitiesManagementAPI.Entities
{
    public class PremisesAddress
    {
        public int Id { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
        public string PostCode { get; set; }
        public bool IsDeleted { get; set; }
        public int PremisesId { get; set; }

    }
}