using System;

namespace API.Models;
public class Imc{
    public String? ImcId { get; set; } = Guid.NewGuid().ToString();
    public Aluno? Aluno { get; set; }
    public String? CriadoEm { get; set; }
    public String? Categoria { get; set; }
    public float Peso { get; set; }
    public float Altura { get; set; }
    public float SomaImc { get; set; }
}
    