# GenAI Travel Planner API

A .NET 8 Web API that generates personalized travel plans using Ollama and Llama 3.2 based on destination, number of days, budget, and interests.

## Tech Stack

* .NET 8
* ASP.NET Core Web API
* C#
* Ollama
* Llama 3.2
* Swagger

## Project Structure

```text
GenAI.API
│
├── Controllers
│   └── TravelController.cs
│
├── Models
│   ├── TravelRequest.cs
│   ├── TravelPlan.cs
│   └── OllamaResponse.cs
│
├── Services
│   ├── IAIService.cs
│   └── OllamaAIService.cs
│
├── Program.cs
└── appsettings.json
```

## API Flow

```text
Client
  ↓
TravelController
  ↓
IAIService
  ↓
OllamaAIService
  ↓
Ollama / Llama 3.2
  ↓
AI Response
  ↓
TravelPlan
  ↓
Client
```

## API Endpoint

**POST**

`/api/Travel/plan`

### Request

```json
{
  "destination": "Vijayawada",
  "days": 2,
  "budget": 5000,
  "interests": "Temples, Food"
}
```

### Response

```json
{
  "destination": "Vijayawada",
  "days": [
    {
      "day": 1,
      "places": [
        "Place 1",
        "Place 2"
      ],
      "activity": "Activity",
      "food": "Food suggestion",
      "estimatedCost": 2500
    }
  ],
  "totalEstimatedCost": 2500
}
```

## How to Run

Make sure Ollama is installed and the `llama3.2` model is available.

```bash
ollama run llama3.2
```

Run the API:

```bash
dotnet run
```

The API can be tested using Swagger or the Angular UI.
