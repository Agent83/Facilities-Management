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
            CreateMap<UpdateContractorDto, Contractor>();
            CreateMap<PremisesTask, PropertyTasksDto>();
            CreateMap<PropertyTasksDto, PremisesTask>();
            CreateMap<CreateAccountantDto, Accountant>();
            CreateMap<PropAccountantDto, Accountant>();
            CreateMap<CreateContPremiseLinkDto, PremisesContractor>();
            CreateMap<Premises, PropertyDto>();
            CreateMap<Premises, UpdatePremiseDto>();
            CreateMap<UpdatePremiseDto, Premises>()
              .ForMember(dest => dest.PremisesAddress,
                map => map.MapFrom( source => source.PremisesAddress));
            CreateMap<Note, NoteDto>();
            CreateMap<NoteDto, Note>();
            CreateMap<CreateContractorDto, Contractor>();
            CreateMap<CreatePropertyDto, Premises>()
                .ForMember(dest => dest.PremisesAddress,
                map => map.MapFrom(
                    source => new PremisesAddress
                    {
                        AddressLine1 = source.AddressLine1,
                        AddressLine2 = source.AddressLine2,
                        City = source.City,
                        PostCode = source.PostCode,
                    }));
        }
    }
}