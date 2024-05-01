using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;


public class Serie
{
    public Serie()
    {
    }

    public Serie(string titulo, string diretor, string elenco, string pais, int anoLancamento, int numeroTemporadas)
    {
        Titulo = titulo;
        Diretor = diretor;
        Elenco = elenco;
        Pais = pais;
        AnoLancamento = anoLancamento;
        NumeroTemporadas = numeroTemporadas;
    }
    [Key]
    public int Id { get; init; }
    public string Titulo { get; set; } = default!;
    public string Diretor { get; set; } = default!;
    public string Elenco { get; set; } = default!;
    public string Pais { get; set; } = default!;
    public int AnoLancamento { get; set; } = default!;
    public int NumeroTemporadas { get; set; } = default!;
    public int Avaliacao { get; set; } = default!;

    public void SetAvaliação()
    {
        Avaliacao = +1;
    }
}
