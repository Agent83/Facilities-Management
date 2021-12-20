namespace FacilitiesManagementAPI.Controllers;

public class PropAccountantController : BaseApiController
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly DataContext _context;

    public PropAccountantController(IMapper mapper, IUnitOfWork unitOfWork, DataContext context)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Accountant>>> GetAccountantsAsync()
    {
        var accountants = await _unitOfWork.AccountantRepository.GetAccountants();
        return Ok(accountants);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Accountant>> GetAccountsAsync(Guid Id)
    {
        return await _unitOfWork.AccountantRepository.GetAccountantById(Id);
    }

    [HttpPost("accountant")]
    public async Task<ActionResult<Accountant>> CreateAccountant(CreateAccountantDto accountant)
    {
        var premAccountant = _mapper.Map<Accountant>(accountant);
        _context.Accountant.Add(premAccountant);
        await _unitOfWork.Complete();

        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult> UpdateAccountant(PropAccountantDto propAccountant)
    {
        var accountant = await _unitOfWork.AccountantRepository.GetAccountantById(propAccountant.Id);
        _mapper.Map(propAccountant, accountant);

        _unitOfWork.AccountantRepository.Update(accountant);
        if (await _unitOfWork.Complete()) return NoContent();

        return BadRequest("Failed to update accountant"); ;
    }

    [HttpDelete("delAccountant/{accId}")]
    public async Task<ActionResult> DeleteAccountant(Guid accId)
    {
        var accountant = await _unitOfWork.AccountantRepository.GetAccountantById(accId);
        List<Premises> premWithAcc = new List<Premises>();
        premWithAcc.AddRange(await _unitOfWork.PremiseRepository.GetPremWithAccAsync(accId));

        foreach(var prem in premWithAcc)
        {
            prem.AccountantId = null;
            prem.Accountant = null;
        }

        _unitOfWork.AccountantRepository.DeleteAccountant(accountant);

        if (await _unitOfWork.Complete()) return Ok();

        return BadRequest("Failed to remove");
    }
}
