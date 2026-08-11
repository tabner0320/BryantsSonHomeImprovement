namespace BryantsSonHomeImprovement.Api.Models;

public class Service
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public string Description { get; set; } = "";

    public string Category { get; set; } = "";

    public decimal StartingPrice { get; set; }

    public bool IsAvailable { get; set; }
}