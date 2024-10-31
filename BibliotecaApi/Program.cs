using BibliotecaApi.Models;
using Microsoft.EntityFrameworkCore;
using BibliotecaApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BibliotecaContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Get all
app.MapGet("/bibliotecas", async (BibliotecaContext db) =>
    await db.Bibliotecas.ToListAsync());

// Get by id
app.MapGet("/bibliotecas/{id}", async (int id, BibliotecaContext db) =>
    await db.Bibliotecas.FindAsync(id)
        is Biblioteca biblioteca
            ? Results.Ok(biblioteca)
            : Results.NotFound());

// Create
app.MapPost("/bibliotecas", async (Biblioteca biblioteca, BibliotecaContext db) =>
{
    db.Bibliotecas.Add(biblioteca);
    await db.SaveChangesAsync();

    return Results.Created($"/bibliotecas/{biblioteca.Id}", biblioteca);
});

// Update
app.MapPut("/bibliotecas/{id}", async (int id, Biblioteca inputBiblioteca, BibliotecaContext db) =>
{
    var biblioteca = await db.Bibliotecas.FindAsync(id);

    if (biblioteca is null) return Results.NotFound();

    biblioteca.Nome = inputBiblioteca.Nome;
    biblioteca.InicioFuncionamento = inputBiblioteca.InicioFuncionamento;
    biblioteca.FimFuncionamento = inputBiblioteca.FimFuncionamento;
    biblioteca.Inauguracao = inputBiblioteca.Inauguracao;
    biblioteca.Contato = inputBiblioteca.Contato;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

// Delete
app.MapDelete("/bibliotecas/{id}", async (int id, BibliotecaContext db) =>
{
    if (await db.Bibliotecas.FindAsync(id) is Biblioteca biblioteca)
    {
        db.Bibliotecas.Remove(biblioteca);
        await db.SaveChangesAsync();
        return Results.Ok(biblioteca);
    }

    return Results.NotFound();
});

app.Run();
