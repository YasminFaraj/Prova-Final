using System;
namespace API.Models;
public class Aluno{
    public String AlunoId { get; set; } = Guid.NewGuid().ToString();
    public Imc? Imc { get; set; }
    public String? ImcId { get; set; }
    public String? Nome { get; set; }
    public String? Sobrenome { get; set; }
    public float Peso { get; set; }
    public float Altura { get; set; }
}