using Domain.Entities;
using Domain.Contracts.UseCases.Film;
using Flix.Application.InterfaceAdapters;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Film;

public class FilmUseCase : IFilmUseCase
{
    private readonly IApplicationDbContext _dbContext;

    public FilmUseCase(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<string> CreateAsync(FilmInputDto input, CancellationToken cancellationToken)
    {

        var newFilm = new Filme(input.Titulo, input.Diretor, input.Elenco, input.Pais, input.Ano);

        await _dbContext.Filme.AddAsync(newFilm, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return newFilm.Titulo;
    }

    public async Task<List<Filme>> GetAllAsync(CancellationToken cancellationToken)
    {
        var allFilm = await _dbContext.Filme.ToListAsync();
        return allFilm;
    }

    public async Task<Filme> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var idFilm = await _dbContext.Filme.FirstOrDefaultAsync(filme => filme.Id == id);

        return idFilm!;
    }

    public async Task<Filme> DeleteByIdAsync(int id, CancellationToken cancellationToken)
    {
        var deletedFilm = await _dbContext.Filme.FirstOrDefaultAsync(filme => filme.Id == id);

        _dbContext.Filme.Remove(deletedFilm!);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return deletedFilm!;

    }

    public async Task<Filme> PutByIdAsync(FilmInputDto input, int id, CancellationToken cancellationToken)
    {

        var getFilm = await _dbContext.Filme.FirstOrDefaultAsync(f => f.Id == id);


        if (getFilm == null)
        {
            throw new Exception("Filme não encontrado");
        }

        if (input.Titulo != null)
            getFilm.Titulo = input.Titulo;
        if (input.Diretor != null)
            getFilm.Diretor = input.Diretor;
        if (input.Elenco != null)
            getFilm.Elenco = input.Elenco;
        if (input.Pais != null)
            getFilm.Pais = input.Pais;
        if (input?.Ano != null)
            getFilm.Ano = input.Ano;

        await _dbContext.SaveChangesAsync(cancellationToken);

        return getFilm;
    }



}
