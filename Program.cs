using SoccerApi;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlite("Data Source=soccer.db"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapScalarApiReference(options =>
    {
        options
            .WithTitle("Minha API")
            .WithTheme(ScalarTheme.BluePlanet)
            .WithOpenApiRoutePattern("/swagger/v1/swagger.json")
            .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
    });
}

app.MapGet("/times", async (AppDBContext db) =>
{
    return await db.Times.ToListAsync();
});

app.MapGet("/times/{id}", async (int id, AppDBContext db) =>
{
    var time = await db.Times.FindAsync(id);
    return time is not null
        ? Results.Ok(time)
        : Results.NotFound("Time not found");
});

app.MapPost("/times", async (AppDBContext db, Time newTime) =>
{
    db.Times.Add(newTime);
    await db.SaveChangesAsync();
    return Results.Created($"O Time {newTime.Name} foi criado com sucesso.", newTime);
});

app.MapPut("/times/{id}", async (int id, Time updatedTime, AppDBContext db) =>
{
    var time = await db.Times.FindAsync(id);
    if (time is null) return Results.NotFound("Time not found");

    time.Name = updatedTime.Name;
    time.City = updatedTime.City;
    time.TitlesBrazil = updatedTime.TitlesBrazil;
    time.TitlesInternacionais = updatedTime.TitlesInternacionais;

    await db.SaveChangesAsync();
    return Results.Ok(time);
});

app.MapDelete("/times/{id}", async (int id, AppDBContext db) =>
{
    var time = await db.Times.FindAsync(id);
    if (time is null) return Results.NotFound("Time not found");

    db.Times.Remove(time);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();
