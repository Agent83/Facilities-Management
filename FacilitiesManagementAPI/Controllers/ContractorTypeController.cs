namespace FacilitiesManagementAPI.Controllers;

public class ContractorTypeController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly DataContext _context;

    public ContractorTypeController(IUnitOfWork unitOfWork, DataContext context)
    {
        _unitOfWork = unitOfWork;
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ContractorType>>> GetContractorTypeAsync()
    {
        var contractorType = await _unitOfWork.ContractorTypeRepository.GetContractorTypes();
        return Ok(contractorType);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ContractorType>> GetContractorTypeById(Guid Id)
    {
        return await _unitOfWork.ContractorTypeRepository.GetContractorTypeByIdAsync(Id);
    }

    [HttpPost("createConType")]
    public async Task<ActionResult<ContractorType>> CreateContactorType(ContractorType contractorType)
    {
        _context.ContractorTypes.Add(contractorType);
        await _unitOfWork.Complete();

        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult> UpdateContactorType(ContractorType contractorType)
    {
        _unitOfWork.ContractorTypeRepository.Update(contractorType);

        if (await _unitOfWork.Complete()) return NoContent();
        return BadRequest("Failed to update contractor type");
    }
}
