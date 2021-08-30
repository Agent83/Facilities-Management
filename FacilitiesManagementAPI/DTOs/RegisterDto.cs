using System.ComponentModel.DataAnnotations;

namespace FacilitiesManagementAPI.DTOs
{
    public class RegisterDto
    { 
        
    [Required]
     public string UserName { get; set; }
     [Required]
     [StringLength(16, MinimumLength = 8)]
     public string Password { get; set; }
        
    }
}