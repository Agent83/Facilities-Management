using System.Linq;
using AutoMapper;
using FacilitiesManagementAPI.DTOs;
using FacilitiesManagementAPI.Entities;
using FacilitiesManagementAPI.Extensions;

namespace FacilitiesManagementAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>();
            CreateMap<Contractor, ContractorDto>();
            CreateMap<PremisesTask, PropertyTasksDto>();
            CreateMap<Premises, PropertyDto>();
            CreateMap<Note, NoteDto>();
               
            
        }
    }
}