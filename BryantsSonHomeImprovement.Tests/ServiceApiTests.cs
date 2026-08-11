using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using BryantsSonHomeImprovement.Api.Models;

namespace BryantsSonHomeImprovement.Tests;

public class ServiceApiTests
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public ServiceApiTests(
        WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetAllServices_ReturnsOk()
    {
        HttpResponseMessage response =
            await _client.GetAsync("/api/services");

        Assert.Equal(
            HttpStatusCode.OK,
            response.StatusCode
        );

        List<Service>? services =
            await response.Content
                .ReadFromJsonAsync<List<Service>>();

        Assert.NotNull(services);
        Assert.NotEmpty(services);
    }

    [Fact]
    public async Task GetService_WithValidId_ReturnsService()
    {
        HttpResponseMessage response =
            await _client.GetAsync("/api/services/1");

        Assert.Equal(
            HttpStatusCode.OK,
            response.StatusCode
        );

        Service? service =
            await response.Content
                .ReadFromJsonAsync<Service>();

        Assert.NotNull(service);
        Assert.Equal(1, service.Id);
        Assert.Equal(
            "Interior Painting",
            service.Name
        );
    }

    [Fact]
    public async Task GetService_WithInvalidId_ReturnsNotFound()
    {
        HttpResponseMessage response =
            await _client.GetAsync("/api/services/999");

        Assert.Equal(
            HttpStatusCode.NotFound,
            response.StatusCode
        );
    }

    [Fact]
    public async Task AddService_ReturnsCreated()
    {
        Service newService = new()
        {
            Id = 50,
            Name = "Deck Repair",
            Description = "Repair damaged deck boards.",
            Category = "Outdoor",
            StartingPrice = 300.00m,
            IsAvailable = true
        };

        HttpResponseMessage response =
            await _client.PostAsJsonAsync(
                "/api/services",
                newService
            );

        Assert.Equal(
            HttpStatusCode.Created,
            response.StatusCode
        );

        Service? createdService =
            await response.Content
                .ReadFromJsonAsync<Service>();

        Assert.NotNull(createdService);
        Assert.Equal(50, createdService.Id);
        Assert.Equal(
            "Deck Repair",
            createdService.Name
        );
    }

    [Fact]
    public async Task UpdateService_ReturnsUpdated()
    {
        Service updatedService = new()
        {
            Id = 1,
            Name = "Premium Interior Painting",
            Description =
                "Professional interior painting service.",
            Category = "Painting",
            StartingPrice = 350.00m,
            IsAvailable = true
        };

        HttpResponseMessage response =
            await _client.PutAsJsonAsync(
                "/api/services/1",
                updatedService
            );

        Assert.Equal(
            HttpStatusCode.OK,
            response.StatusCode
        );

        Service? result =
            await response.Content
                .ReadFromJsonAsync<Service>();

        Assert.NotNull(result);

        Assert.Equal(
            "Premium Interior Painting",
            result.Name
        );

        Assert.Equal(
            350.00m,
            result.StartingPrice
        );
    }

    [Fact]
    public async Task DeleteService_ReturnsNoContent()
    {
        Service newService = new()
        {
            Id = 60,
            Name = "Test Service",
            Description =
                "Temporary service used for testing.",
            Category = "Test",
            StartingPrice = 100.00m,
            IsAvailable = true
        };

        HttpResponseMessage createResponse =
            await _client.PostAsJsonAsync(
                "/api/services",
                newService
            );

        Assert.Equal(
            HttpStatusCode.Created,
            createResponse.StatusCode
        );

        HttpResponseMessage deleteResponse =
            await _client.DeleteAsync(
                "/api/services/60"
            );

        Assert.Equal(
            HttpStatusCode.NoContent,
            deleteResponse.StatusCode
        );
    }
}