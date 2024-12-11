using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();
var app = builder.Build();


app.MapGet("/", () => "API de academia");

// Cadastrar Aluno
// POST http:/localhost:5134/api/aluno/cadastrar
app.MapPost("/api/aluno/cadastrar", ([FromServices]AppDataContext ctx,
[FromBody] Aluno aluno) =>
{
    Imc? imc = ctx.Imcs.Find(aluno.ImcId);
    if(imc == null){
        return Results.NotFound("IMC não encontrado");
    }

    aluno.Imc = imc;
    ctx.Alunos.Add(aluno);
    ctx.SaveChanges();
    return Results.Created("", aluno);
});

// Listar Aluno
// GET http://localhost:5134/api/aluno/listar
app.MapGet("/api/aluno/listar", ([FromServices] AppDataContext ctx) =>
{
    if(ctx.Alunos.Any()){
        return Results.Ok(ctx.Alunos.Include(x => x.Imc).ToList());
    }
    return Results.NotFound("Nenhum aluno encontrado");
});

// Cadastrar IMC
// POST http:/localhost:5134/api/imc/cadastrar
app.MapPost("/api/imc/cadastrar", ([FromServices]AppDataContext ctx,
[FromBody] Imc imc) =>
{
    ctx.Imcs.Add(imc);
    ctx.SaveChanges();
    return Results.Created("", imc);
});

// Listar IMC
// GET http://localhost:5134/api/imc/listar
app.MapGet("/api/imc/listar", ([FromServices] AppDataContext ctx) =>
{
    if(ctx.Alunos.Any()){
        return Results.Ok(ctx.Imcs.ToList());
    }
    return Results.NotFound("Nenhum IMC encontrado.");
});

// Alterar IMC
// PUT http://localhost:5134/api/imc/alterar
app.MapPut("/api/imc/alterar", ([FromServices] AppDataContext ctx, [FromBody] Imc imcAlterado, 
[FromRoute] string id) =>
{
    Imc? imc = ctx.Imcs.Find(id);
    if(imc == null){
        return Results.NotFound("Nenhum IMC encontrado");
    }
    
    Imc? SomaImc = imc.Peso / imc.Altura;

    if(imc.SomaImc >= 18.5){
        imc.Categoria = "Magreza";
    }else if(imc.SomaImc >= 18.6 || imc.SomaImc <= 24.9){
        imc.Categoria = "Normal";
    }else if(imc.SomaImc >= 25 || imc.SomaImc <= 29.9){
        imc.Categoria = "Sobrepeso";
    }else if(imc.SomaImc >= 30 || imc.SomaImc <= 39.9){
        imc.Categoria = "Obeso";
    }else{
        imc.Categoria = "Obesidade grave";
    }

    ctx.Imcs.Update(imc);
    ctx.SaveChanges();
    return Results.Ok(ctx.Imcs.ToList());

});

app.Run();