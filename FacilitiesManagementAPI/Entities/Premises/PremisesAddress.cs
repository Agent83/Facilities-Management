namespace FacilitiesManagementAPI.Entities
{
    public class PremisesAddress
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
        public string Conty { get; set; }
        public string PremisesPhone { get; set; }
        public bool IsDeleted { get; set; }

    }
}