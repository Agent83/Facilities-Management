using FacilitiesManagementAPI.Entities;

namespace FacilitiesManagementAPI.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}