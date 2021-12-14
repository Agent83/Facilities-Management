using AutoMapper;
using FacilitiesManagementAPI.Entities;
using FacilitiesManagementAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace FacilitiesManagementAPI.Data
{
    public class PremiseContractorRepository : IPremiseContractorRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PremiseContractorRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


    }
}
