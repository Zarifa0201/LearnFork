using LearnForkApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IChatService, ChatService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapGet("/", () => "LearnFork API is running. Open /swagger to test endpoints.");

app.MapGet("/health", () => Results.Ok(new
{
    status = "Healthy",
    service = "LearnFork API",
    timestamp = DateTime.UtcNow
}));

app.MapControllers();

app.Run();
