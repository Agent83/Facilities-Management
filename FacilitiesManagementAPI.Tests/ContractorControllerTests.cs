using System.Net;
using System.Net.Http.Json;
using FacilitiesManagementAPI.Data;
using FacilitiesManagementAPI.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace FacilitiesManagementAPI.Tests;

public class ContractorControllerTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;
    private readonly CustomWebApplicationFactory _factory;

    public ContractorControllerTests(CustomWebApplicationFactory factory)
    {
        _factory = factory;
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task LinkContractor_ReturnsOkAndPersistsLink()
    {
        var linkDto = new ContPremiseLinkDto
        {
            PremisesId = _factory.ExistingPremisesId,
            ContractorId = _factory.ExistingContractorId
        };

        using (var scope = _factory.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<DataContext>();
            var alreadyLinked = await context.PremisesContractors
                .AsNoTracking()
                .AnyAsync(pc => pc.PremisesId == linkDto.PremisesId && pc.ContractorId == linkDto.ContractorId);
            Assert.False(alreadyLinked);
        }

        var response = await _client.PostAsJsonAsync("/api/contractor/linkContractor", linkDto);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        using (var scope = _factory.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<DataContext>();
            var persistedLink = await context.PremisesContractors
                .AsNoTracking()
                .SingleOrDefaultAsync(pc => pc.PremisesId == linkDto.PremisesId && pc.ContractorId == linkDto.ContractorId);

            Assert.NotNull(persistedLink);
        }
    }
}

