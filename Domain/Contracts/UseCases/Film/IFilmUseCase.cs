using Domain.Entities;

namespace Domain.Contracts.UseCases.Film
{
    public interface IFilmUseCase
    {
        Task<string> CreateAsync(FilmInputDto input, CancellationToken cancellationToken);
        Task<List<Filme>> GetAllAsync(CancellationToken cancellationToken);
        Task<Filme> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<Filme> DeleteByIdAsync(int id, CancellationToken cancellationToken);
        Task<Filme> PutByIdAsync(FilmInputDto film, int id, CancellationToken cancellationToken);


    }
}
