namespace FacilitiesManagementAPI.Controllers;

public class ContractorController : BaseApiController
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly DataContext _context;

    public ContractorController(IMapper mapper, IUnitOfWork unitOfWork, DataContext context)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ContractorDto>>> GetContractors([FromQuery] PageListParams pageListParams)
    {
        var contractors = await _unitOfWork.ContractorRepository.GetContractorsAsync(pageListParams);
        Response.AddPaginationHeader(contractors.CurrentPage, contractors.PageSize,
        contractors.TotalCount, contractors.TotalPages);
        return Ok(contractors);
    }

    [HttpGet("list")]
    public async Task<ActionResult<IEnumerable<ContractorDto>>> GetContractorsList()
    {
        var contractors = await _unitOfWork.ContractorRepository.GetContractorsListAsync();
        
        return Ok(contractors);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ContractorDto>> GetContractorById(Guid id)
    {
        return await _unitOfWork.ContractorRepository.GetContractorByIdAsync(id);
    }

    [HttpPost("createcon")]
    public async Task<ActionResult<ContractorDto>> CreateContractor(CreateContractorDto contractorDto)
    {
        var contractor = _mapper.Map<Contractor>(contractorDto);

        _context.Contractors.Add(contractor);
        await _unitOfWork.Complete();

        return Ok();
    }

    [HttpPost("linkContractor")]
    public async Task<ActionResult<PremisesContractor>> CreateContractorLink(CreateContractorDto createContractorDto)
    {
        var conLink = _mapper.Map<PremisesContractor>(createContractorDto);

        _context.PremisesContractors.Add(conLink);
        await _unitOfWork.Complete();
        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult> UpdateContractor(UpdateContractorDto contractorDto)
    {
        var contractor = await _unitOfWork.ContractorRepository.GetContractByIdAsync(contractorDto.Id);
        _mapper.Map(contractorDto, contractor);

        _unitOfWork.ContractorRepository.Update(contractor);

        if (await _unitOfWork.Complete()) return NoContent();

        return BadRequest("Failed to update property");
    }


    [HttpDelete("delContractor/{conId}")]
    public async Task<ActionResult> DeleteContractor(Guid conId)
    {
        var contractor = await _unitOfWork.ContractorRepository.GetContractByIdAsync(conId);

        _unitOfWork.ContractorRepository.DeleteContractor(contractor);

        if (await _unitOfWork.Complete()) return Ok();

        return BadRequest("Failed to remove");
    }
}
