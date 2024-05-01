using Domain.Entities;

namespace Domain.Contracts.UseCases.Book;

public interface IBookUseCase
{
    Task<string> CreateAsync(BookInputDto input, CancellationToken cancellationToken);
    Task<List<Livro>> GetAllAsync(CancellationToken cancellationToken);
    Task<Livro> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<Livro> DeleteByIdAsync(int id, CancellationToken cancellationToken);
    Task<Livro> PutByIdAsync(BookInputDto film, int id, CancellationToken cancellationToken);
}
