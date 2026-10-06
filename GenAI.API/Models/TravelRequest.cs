namespace GenAI.API.Models;

public class TravelRequest
{
    public string Destination { get; set; } = string.Empty;

    public int Days { get; set; }

    public decimal Budget { get; set; }

    public string Interests { get; set; } = string.Empty;
}