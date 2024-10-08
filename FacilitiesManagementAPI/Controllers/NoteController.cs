﻿namespace FacilitiesManagementAPI.Controllers;

public class NoteController : BaseApiController
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly DataContext _context;

    public NoteController(IMapper mapper, IUnitOfWork unitOfWork, DataContext context)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _context = context;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Note>>> GetNotesAsync()
    {
        var notes = await _unitOfWork.NoteRepository.GetNotesAsync();
        return Ok(notes);
    }
    [HttpGet]
    public async Task<ActionResult<Note>> GetNoteByIdAsync(Guid Id)
    {
        return await _unitOfWork.NoteRepository.GetNoteByIdAsync(Id);
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<NoteDto>>> GetNotesDtoAsync()
    {
        var notes = await _unitOfWork.NoteRepository.GetNotesDtoAsync();
        return Ok(notes);
    }
    [HttpGet]
    public async Task<ActionResult<NoteDto>> GetNoteDtoByIdAsync(Guid Id)
    {
        return await _unitOfWork.NoteRepository.GetNoteDtoByIdAsync(Id);
    }

    [HttpPost("createNote")]
    public async Task<ActionResult<NoteDto>> CreateContractor(CreateNoteDto noteDto)
    {
        var note = _mapper.Map<Note>(noteDto);

        _context.Note.Add(note);
        await _unitOfWork.Complete();

        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult> UpdateContractor(NoteDto noteDto)
    {
        var note = await _unitOfWork.NoteRepository.GetNoteByIdAsync(noteDto.Id);
        _mapper.Map(noteDto, note);

        _unitOfWork.NoteRepository.Update(note);

        if (await _unitOfWork.Complete()) return NoContent();

        return BadRequest("Failed to update property");
    }
}

