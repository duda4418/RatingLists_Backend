using RatingLists_Backend.Configuration;

EnviromentConfig.Load(Path.Combine(AppContext.BaseDirectory, ".env"));
EnviromentConfig.Load(Path.Combine(Directory.GetCurrentDirectory(), ".env"));

var builder = WebApplication.CreateBuilder(args);

builder.Configuration["ConnectionStrings:Postgres"] = EnviromentConfig.GetPostgresConnectionString();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
