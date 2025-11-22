var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); // Enable Controllers
builder.Services.AddOpenApi();

// Register your EventService so Controllers can use it
builder.Services.AddSingleton<Backend.Services.EventService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); // Activate Controllers

app.Run();