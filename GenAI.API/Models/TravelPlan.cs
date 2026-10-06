namespace GenAI.API.Models;

public class TravelPlan
{
    public string Destination { get; set; } = string.Empty;

    public List<TravelDay> Days { get; set; } = [];

    public decimal TotalEstimatedCost { get; set; }
}

public class TravelDay
{
    public int Day { get; set; }

    public List<string> Places { get; set; } = [];

    public string Activity { get; set; } = string.Empty;

    public string Food { get; set; } = string.Empty;

    public decimal EstimatedCost { get; set; }
}