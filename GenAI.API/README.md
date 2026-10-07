AI Travel Planner API
Overview

A .NET 8 Web API that generates AI-based travel plans using Ollama.
The API receives travel details, sends a prompt to the LLM, processes the AI response, and returns a structured travel plan as JSON.

Tech Stack
.NET 8
ASP.NET Core Web API
C#
Ollama / LLM
HttpClient
JSON
Swagger
Project Structure
AI Travel Planner API
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
├── appsettings.json
└── README.md
Request Flow
Angular UI
    ↓
TravelController
    ↓
IAIService
    ↓
OllamaAIService
    ↓
Ollama / LLM
    ↓
AI JSON Response
    ↓
TravelPlan
    ↓
Angular UI
API Endpoint
POST /api/travel
Request
{
  "destination": "Hyderabad",
  "days": 3
}
Response
{
  "destination": "Hyderabad",
  "days": [
    {
      "day": 1,
      "activities": [
        "Visit Charminar",
        "Explore Laad Bazaar"
      ]
    }
  ]
}
Key Components
TravelController – Handles API requests and responses.
IAIService – Defines the AI service contract.
OllamaAIService – Communicates with Ollama and processes the LLM response.
TravelRequest – Represents the travel details received from the UI.
TravelPlan – Represents the structured travel plan returned to the UI.
OllamaResponse – Represents the response received from Ollama.
Running the API
dotnet restore
dotnet run

Swagger:

https://localhost:<port>/swagger
Prerequisites
.NET 8 SDK
Ollama
Required Ollama model