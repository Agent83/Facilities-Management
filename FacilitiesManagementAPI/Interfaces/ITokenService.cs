using FacilitiesManagementAPI.Entities;
using System.Threading.Tasks;

namespace FacilitiesManagementAPI.Interfaces
{
    public interface ITokenService
    {
       Task<string> CreateToken(AppUser user);
    }
}