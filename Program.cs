using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configura o Swagger para documentação
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "Pets API", 
        Description = "API para gerenciamento de animais", 
        Version = "v1" 
    });
});

// Configura o banco de dados em memória
builder.Services.AddDbContext<DataContext>(options => 
    options.UseInMemoryDatabase("petsdb"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pets API v1"));
}

app.UseHttpsRedirection();

// Endpoints da API
app.MapGet("/animals", async (DataContext db) => 
    await db.Animais.ToListAsync());

app.MapGet("/animal/{id}", async (DataContext db, int id) => 
    await db.Animais.FindAsync(id) is Animal animal 
        ? Results.Ok(animal) 
        : Results.NotFound());

app.MapPut("/animal/{id}", async (DataContext db, Animal updatedAnimal, int id) =>
{
    var animal = await db.Animais.FindAsync(id);
    if (animal is null) return Results.NotFound();

    animal.Nome = updatedAnimal.Nome;
    animal.Idade = updatedAnimal.Idade;
    animal.Cor = updatedAnimal.Cor;
    animal.Tipo = updatedAnimal.Tipo;
    animal.PesoKg = updatedAnimal.PesoKg;
    animal.Vacinado = updatedAnimal.Vacinado;

    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/animal/{id}", async (DataContext db, int id) =>
{
    var animal = await db.Animais.FindAsync(id);
    if (animal is null) return Results.NotFound();

    db.Animais.Remove(animal);
    await db.SaveChangesAsync();
    return Results.Ok();
});

app.MapPost("/animal", async (DataContext db, Animal animal) =>
{
    await db.Animais.AddAsync(animal);
    await db.SaveChangesAsync();
    return Results.Created($"/animal/{animal.Id}", animal);
});

app.Run();