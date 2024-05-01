namespace Domain.Contracts.UseCases.Book;

public class BookInputDto
{
    public string Titulo { get; set; } = default!;
    public string Autor { get; set; } = default!;
    public string Editora { get; set; } = default!;
    public string Pais { get; set; } = default!;
    public int AnoLancamento { get; set; } = default!;
}
