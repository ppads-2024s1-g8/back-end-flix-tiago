namespace Domain.Contracts.UseCases.Series;

public class SerieInputDto
{
    public string Titulo { get; set; } = default!;
    public string Diretor { get; set; } = default!;
    public string Elenco { get; set; } = default!;
    public string Pais { get; set; } = default!;
    public int AnoLancamento { get; set; } = default!;
    public int NumeroTemporadas { get; set; } = default!;
}
