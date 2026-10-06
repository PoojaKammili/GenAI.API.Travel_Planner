using GenAI.API.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddScoped<IAIService, OllamaAIService>();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("http://localhost:4200") // Allow only the 4200 port
              .AllowAnyHeader()
              .AllowAnyMethod();
    });

    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin() // Allow all origins
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

//register the URI of ollama (third party app)
builder.Services.AddHttpClient<IAIService, OllamaAIService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:11434/");
    client.Timeout = TimeSpan.FromMinutes(5);
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin");
app.UseAuthorization();

app.MapControllers();

app.Run();
