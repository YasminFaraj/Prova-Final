using Microsoft.EntityFrameworkCore;
using System;

namespace API.Models;

public class AppDataContext : DbContext
{
    public DbSet<Aluno> Alunos { get; set; }
    public DbSet<Imc> Imcs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=YasminFaraj.db");
    }
    /*protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Imc>().HasData(
            new Imc { ImcId = "", Peso = "75"}
        );
    }*/
}