## GenAI Travel Planner API

A .NET 8 Web API that generates personalized travel plans using Ollama and Llama 3.2 based on destination, number of days, budget, and interests.

## Tech Stack
.NET 8
ASP.NET Core Web API
C#
Ollama
Llama 3.2
Swagger

## Project Structure
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

## API Flow
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

## API Endpoint
Generate Travel Plan

POST
/api/Travel/plan

## How to Run
1. Start Ollama

Make sure Ollama is installed and the llama3.2 model is available.

ollama run llama3.2
2. Run the API
dotnet run

The API can then be tested using Swagger or the Angular UI.

## Key Responsibilities
TravelController – Validates the request and handles the API endpoint.
IAIService – Defines the AI service contract.
OllamaAIService – Sends the prompt to Ollama and receives the AI response.
TravelRequest – Represents user input.
TravelPlan – Represents the structured travel plan.
OllamaResponse – Represents the response received from Ollama.

## Application Flow
Angular UI
    ↓
.NET Web API
    ↓
Create AI Prompt
    ↓
Ollama / Llama 3.2
    ↓
JSON Response
    ↓
Deserialize to TravelPlan
    ↓
Return JSON to Angular
