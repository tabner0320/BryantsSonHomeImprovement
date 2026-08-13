namespace BryantsSonHomeImprovement.Api.Models;

public class EstimateRequest
{
    public int Id { get; set; }

    public string CustomerName { get; set; } = "";

    public string CustomerPhone { get; set; } = "";

    public string CustomerEmail { get; set; } = "";

    public string Address { get; set; } = "";

    public string ServiceNeeded { get; set; } = "";

    public DateTime PreferredDate { get; set; }

    public string ProjectDescription { get; set; } = "";

    public DateTime SubmittedAt { get; set; }
}