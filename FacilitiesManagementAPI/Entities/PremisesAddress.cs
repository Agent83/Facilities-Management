using System.ComponentModel.DataAnnotations.Schema;

namespace FacilitiesManagementAPI.Entities
{
    public class PremisesAddress
    {
        [ForeignKey("Premises")]
        public int Id { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
        public string PostCode { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Premises Premises {  get; set; }

    }
}