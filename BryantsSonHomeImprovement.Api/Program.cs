using BryantsSonHomeImprovement.Api.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowWebApp", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("AllowWebApp");

// -------------------------
// Service Data
// -------------------------

List<Service> services = new()
{
    new Service
    {
        Id = 1,
        Name = "Interior Painting",
        Description = "Professional painting for interior rooms.",
        Category = "Painting",
        StartingPrice = 250.00m,
        IsAvailable = true
    },

    new Service
    {
        Id = 2,
        Name = "Drywall Repair",
        Description = "Repair holes, cracks, and damaged drywall.",
        Category = "Repair",
        StartingPrice = 150.00m,
        IsAvailable = true
    },

    new Service
    {
        Id = 3,
        Name = "Flooring Installation",
        Description =
            "Installation of laminate, vinyl, and hardwood flooring.",
        Category = "Flooring",
        StartingPrice = 500.00m,
        IsAvailable = true
    }
};


// -------------------------
// Estimate Data
// -------------------------

List<EstimateRequest> estimates = new();


// -------------------------
// Root Endpoint
// -------------------------

app.MapGet("/", () =>
{
    return "Bryant's Son Home Improvement API is running!";
});


// -------------------------
// Service Endpoints
// -------------------------

app.MapGet("/api/services", () =>
{
    return Results.Ok(services);
});


app.MapGet("/api/services/{id}", (int id) =>
{
    Service? service =
        services.FirstOrDefault(s => s.Id == id);

    return service is not null
        ? Results.Ok(service)
        : Results.NotFound();
});


app.MapPost("/api/services", (Service newService) =>
{
    newService.Id =
        services.Count == 0
            ? 1
            : services.Max(s => s.Id) + 1;

    services.Add(newService);

    return Results.Created(
        $"/api/services/{newService.Id}",
        newService
    );
});


app.MapPut(
    "/api/services/{id}",
    (int id, Service updatedService) =>
{
    Service? existingService =
        services.FirstOrDefault(s => s.Id == id);

    if (existingService is null)
    {
        return Results.NotFound();
    }

    existingService.Name =
        updatedService.Name;

    existingService.Description =
        updatedService.Description;

    existingService.Category =
        updatedService.Category;

    existingService.StartingPrice =
        updatedService.StartingPrice;

    existingService.IsAvailable =
        updatedService.IsAvailable;

    return Results.Ok(existingService);
});


app.MapDelete("/api/services/{id}", (int id) =>
{
    Service? service =
        services.FirstOrDefault(s => s.Id == id);

    if (service is null)
    {
        return Results.NotFound();
    }

    services.Remove(service);

    return Results.NoContent();
});


// -------------------------
// Estimate Endpoints
// -------------------------

app.MapGet("/api/estimates", () =>
{
    return Results.Ok(estimates);
});


app.MapGet("/api/estimates/{id:int}", (int id) =>
{
    EstimateRequest? estimate =
        estimates.FirstOrDefault(e => e.Id == id);

    return estimate is not null
        ? Results.Ok(estimate)
        : Results.NotFound();
});


app.MapPost(
    "/api/estimates",
    (EstimateRequest estimate) =>
{
    estimate.Id =
        estimates.Count == 0
            ? 1
            : estimates.Max(e => e.Id) + 1;

    estimate.SubmittedAt = DateTime.Now;

    estimates.Add(estimate);

    return Results.Created(
        $"/api/estimates/{estimate.Id}",
        estimate
    );
});


app.Run();

public partial class Program { }