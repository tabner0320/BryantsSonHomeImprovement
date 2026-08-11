using System.Net.Http.Json;
using BryantsSonHomeImprovement.Console.Models;

using HttpClient client = new HttpClient();

client.BaseAddress = new Uri("http://localhost:5270");

bool running = true;

while (running)
{
    Console.WriteLine();
    Console.WriteLine("=========================================");
    Console.WriteLine(" Bryant's Son Home Improvement");
    Console.WriteLine("=========================================");
    Console.WriteLine("1. View All Services");
    Console.WriteLine("2. View Service by ID");
    Console.WriteLine("3. Add Service");
    Console.WriteLine("4. Update Service");
    Console.WriteLine("5. Delete Service");
    Console.WriteLine("6. Exit");
    Console.WriteLine();

    Console.Write("Select an option: ");
    string? choice = Console.ReadLine();

    Console.WriteLine();

    switch (choice)
    {
        case "1":
            await ViewAllServices();
            break;

        case "2":
            await ViewServiceById();
            break;

        case "3":
            await AddService();
            break;

        case "4":
            await UpdateService();
            break;

        case "5":
            await DeleteService();
            break;

        case "6":
            running = false;
            Console.WriteLine("Closing application...");
            break;

        default:
            Console.WriteLine("Invalid option. Please select 1 through 6.");
            break;
    }
}

async Task ViewAllServices()
{
    try
    {
        List<Service>? services =
            await client.GetFromJsonAsync<List<Service>>("/api/services");

        if (services is null || services.Count == 0)
        {
            Console.WriteLine("No services found.");
            return;
        }

        Console.WriteLine("Available Services");
        Console.WriteLine("------------------");

        foreach (Service service in services)
        {
            DisplayService(service);
        }
    }
    catch (HttpRequestException ex)
    {
        Console.WriteLine("Could not connect to the API.");
        Console.WriteLine(ex.Message);
    }
}

async Task ViewServiceById()
{
    Console.Write("Enter service ID: ");

    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        Console.WriteLine("Invalid ID.");
        return;
    }

    HttpResponseMessage response =
        await client.GetAsync($"/api/services/{id}");

    if (response.IsSuccessStatusCode)
    {
        Service? service =
            await response.Content.ReadFromJsonAsync<Service>();

        if (service is not null)
        {
            DisplayService(service);
        }
    }
    else
    {
        Console.WriteLine("Service not found.");
    }
}

async Task AddService()
{
    Console.Write("Service name: ");
    string name = Console.ReadLine() ?? "";

    Console.Write("Description: ");
    string description = Console.ReadLine() ?? "";

    Console.Write("Category: ");
    string category = Console.ReadLine() ?? "";

    Console.Write("Starting price: ");

    if (!decimal.TryParse(Console.ReadLine(), out decimal price))
    {
        Console.WriteLine("Invalid price.");
        return;
    }

    Service newService = new()
    {
        Id = Random.Shared.Next(100, 1000),
        Name = name,
        Description = description,
        Category = category,
        StartingPrice = price,
        IsAvailable = true
    };

    HttpResponseMessage response =
        await client.PostAsJsonAsync("/api/services", newService);

    if (response.IsSuccessStatusCode)
    {
        Service? createdService =
            await response.Content.ReadFromJsonAsync<Service>();

        Console.WriteLine("Service added successfully.");

        if (createdService is not null)
        {
            DisplayService(createdService);
        }
    }
    else
    {
        Console.WriteLine("Unable to add service.");
    }
}

async Task UpdateService()
{
    Console.Write("Enter service ID to update: ");

    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        Console.WriteLine("Invalid ID.");
        return;
    }

    Console.Write("New service name: ");
    string name = Console.ReadLine() ?? "";

    Console.Write("New description: ");
    string description = Console.ReadLine() ?? "";

    Console.Write("New category: ");
    string category = Console.ReadLine() ?? "";

    Console.Write("New starting price: ");

    if (!decimal.TryParse(Console.ReadLine(), out decimal price))
    {
        Console.WriteLine("Invalid price.");
        return;
    }

    Service updatedService = new()
    {
        Id = id,
        Name = name,
        Description = description,
        Category = category,
        StartingPrice = price,
        IsAvailable = true
    };

    HttpResponseMessage response =
        await client.PutAsJsonAsync(
            $"/api/services/{id}",
            updatedService
        );

    if (response.IsSuccessStatusCode)
    {
        Service? result =
            await response.Content.ReadFromJsonAsync<Service>();

        Console.WriteLine("Service updated successfully.");

        if (result is not null)
        {
            DisplayService(result);
        }
    }
    else
    {
        Console.WriteLine("Service not found.");
    }
}

async Task DeleteService()
{
    Console.Write("Enter service ID to delete: ");

    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        Console.WriteLine("Invalid ID.");
        return;
    }

    HttpResponseMessage response =
        await client.DeleteAsync($"/api/services/{id}");

    if (response.IsSuccessStatusCode)
    {
        Console.WriteLine("Service deleted successfully.");
    }
    else
    {
        Console.WriteLine("Service not found.");
    }
}

void DisplayService(Service service)
{
    Console.WriteLine();
    Console.WriteLine($"ID: {service.Id}");
    Console.WriteLine($"Name: {service.Name}");
    Console.WriteLine($"Description: {service.Description}");
    Console.WriteLine($"Category: {service.Category}");
    Console.WriteLine($"Starting Price: {service.StartingPrice:C}");
    Console.WriteLine($"Available: {service.IsAvailable}");
    Console.WriteLine("-----------------------------------------");
}