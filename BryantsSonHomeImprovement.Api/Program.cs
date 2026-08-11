using BryantsSonHomeImprovement.Api.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Commented out for easier local HTTP testing
// app.UseHttpsRedirection();

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
        Description = "Installation of laminate, vinyl, and hardwood flooring.",
        Category = "Flooring",
        StartingPrice = 500.00m,
        IsAvailable = true
    }
};

app.MapGet("/", () =>
{
    return "Bryant's Son Home Improvement API is running!";
});

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
    services.Add(newService);

    return Results.Created(
        $"/api/services/{newService.Id}",
        newService
    );
});

app.MapPut("/api/services/{id}", (int id, Service updatedService) =>
{
    Service? existingService =
        services.FirstOrDefault(s => s.Id == id);

    if (existingService is null)
    {
        return Results.NotFound();
    }

    existingService.Name = updatedService.Name;
    existingService.Description = updatedService.Description;
    existingService.Category = updatedService.Category;
    existingService.StartingPrice = updatedService.StartingPrice;
    existingService.IsAvailable = updatedService.IsAvailable;

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

app.Run();

public partial class Program { }