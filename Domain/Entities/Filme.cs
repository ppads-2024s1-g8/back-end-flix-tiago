using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Filme
{
    public Filme(string titulo, string diretor, string elenco, string pais, int ano)
    {
        Titulo = titulo;
        Diretor = diretor;
        Elenco = elenco;
        Pais = pais;
        Ano = ano;
    }

    public Filme()
    {
        
    }
    [Key]
    public int Id { get; init; }
    public string Titulo { get; set; } = default!;
    public string Diretor { get; set; } = default!;
    public string Elenco { get; set; } = default!;
    public string Pais { get; set; } = default!;
    public int Ano { get; set; } = default!;
    public int Avaliacao { get; set; }

}
    