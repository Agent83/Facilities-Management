using System.Net;
using System.Net.Http.Json;
using FacilitiesManagementAPI.DTOs;
using FacilitiesManagementAPI.Entities;
using Xunit;

namespace FacilitiesManagementAPI.Tests;

public class NoteControllerTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;
    private readonly CustomWebApplicationFactory _factory;

    public NoteControllerTests(CustomWebApplicationFactory factory)
    {
        _factory = factory;
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetNotes_ReturnsOkWithNotes()
    {
        var response = await _client.GetAsync("/api/note");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var notes = await response.Content.ReadFromJsonAsync<List<Note>>();
        Assert.NotNull(notes);
        Assert.Contains(notes!, note => note.Id == _factory.ExistingNoteId &&
                                        note.NoteContent == "Routine safety inspection completed.");
        Assert.Contains(notes!, note => note.Id == _factory.SecondaryNoteId);
    }

    [Fact]
    public async Task GetNote_ById_ReturnsSingleNote()
    {
        var response = await _client.GetAsync($"/api/note/{_factory.ExistingNoteId}");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var note = await response.Content.ReadFromJsonAsync<Note>();
        Assert.NotNull(note);
        Assert.Equal(_factory.ExistingNoteId, note!.Id);
        Assert.Equal("Routine safety inspection completed.", note.NoteContent);
    }

    [Fact]
    public async Task GetNotesDto_ReturnsOkWithNoteDtos()
    {
        var response = await _client.GetAsync("/api/note/dto");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var noteDtos = await response.Content.ReadFromJsonAsync<List<NoteDto>>();
        Assert.NotNull(noteDtos);
        Assert.Contains(noteDtos!, note => note.Id == _factory.ExistingNoteId &&
                                           note.NoteContent == "Routine safety inspection completed.");
    }

    [Fact]
    public async Task GetNoteDto_ById_ReturnsSingleNoteDto()
    {
        var response = await _client.GetAsync($"/api/note/dto/{_factory.ExistingNoteId}");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var noteDto = await response.Content.ReadFromJsonAsync<NoteDto>();
        Assert.NotNull(noteDto);
        Assert.Equal(_factory.ExistingNoteId, noteDto!.Id);
        Assert.Equal("Routine safety inspection completed.", noteDto.NoteContent);
    }
}
