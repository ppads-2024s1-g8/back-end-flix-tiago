using Domain.Entities;

namespace Domain.Contracts.UseCases.Series;

public interface ISerieUseCase
{
    Task<string> CreateAsync(SerieInputDto input, CancellationToken cancellationToken);
    Task<List<Serie>> GetAllAsync(CancellationToken cancellationToken);
    Task<Serie> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<Serie> DeleteByIdAsync(int id, CancellationToken cancellationToken);
    Task<Serie> PutByIdAsync(SerieInputDto Serie, int id, CancellationToken cancellationToken);
}
