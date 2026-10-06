using System.Text.Json;
using GenAI.API.Models;
using GenAI.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace GenAI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TravelController : ControllerBase
{
    private readonly IAIService _aiService;

    public TravelController(IAIService aiService)
    {
        _aiService = aiService;
    }

    [HttpPost("plan")]
    public async Task<IActionResult> CreatePlan(
        [FromBody] TravelRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Destination))
        {
            return BadRequest("Destination is required.");
        }

        if (request.Days <= 0)
        {
            return BadRequest("Days must be greater than 0.");
        }

        var prompt = $$"""
            Create a travel plan for {{request.Destination}} for {{request.Days}} days.

            Budget: {{request.Budget}}
            Interests: {{request.Interests}}

            Return ONLY valid JSON.
            Do not include markdown, explanations, or extra text.

            Use exactly this format:

            {
              "destination": "Goa",
              "days": [
                {
                  "day": 1,
                  "places": ["Place 1", "Place 2"],
                  "activity": "Activity",
                  "food": "Food suggestion",
                  "estimatedCost": 3000
                }
              ],
              "totalEstimatedCost": 9000
            }

            Keep the information short and practical.
            """;

        var aiResponse = await _aiService.GenerateAsync(prompt);

        var travelPlan = JsonSerializer.Deserialize<TravelPlan>(
            aiResponse,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

        if (travelPlan == null)
        {
            return BadRequest("Unable to create travel plan.");
        }

        return Ok(travelPlan);
    }
}