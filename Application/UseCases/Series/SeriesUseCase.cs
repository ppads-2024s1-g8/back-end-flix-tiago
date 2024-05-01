using Domain.Contracts.UseCases.Series;
using Domain.Entities;
using Flix.Application.InterfaceAdapters;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Series;

public class SeriesUseCase : ISerieUseCase
{
    private readonly IApplicationDbContext _dbContext;

    public SeriesUseCase(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<string> CreateAsync(SerieInputDto input, CancellationToken cancellationToken)
    {
        var newSerie = new Serie(input.Titulo,
                               input.Diretor,
                               input.Elenco,
                               input.Pais,
                               input.AnoLancamento,
                               input.NumeroTemporadas);

        await _dbContext.Serie.AddAsync(newSerie, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return newSerie.Titulo;
    }

    public async Task<Serie> DeleteByIdAsync(int id, CancellationToken cancellationToken)
    {
        var deletedSerie = await _dbContext.Serie.FirstOrDefaultAsync(serie => serie.Id == id);

        _dbContext.Serie.Remove(deletedSerie!);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return deletedSerie!;
    }

    public async Task<List<Serie>> GetAllAsync(CancellationToken cancellationToken)
    {
        var allSerie = await _dbContext.Serie.ToListAsync();
        return allSerie;
    }

    public async Task<Serie> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var idSerie = await _dbContext.Serie.FirstOrDefaultAsync(serie => serie.Id == id);

        return idSerie!;
    }

    public async Task<Serie> PutByIdAsync(SerieInputDto input, int id, CancellationToken cancellationToken)
    {
        var getSerie = await _dbContext.Serie.FirstOrDefaultAsync(s => s.Id == id);


        if (getSerie == null)
        {
            throw new Exception("Filme não encontrado");
        }

        if (input.Titulo != null)
            getSerie.Titulo = input.Titulo;
        if (input.Diretor != null)
            getSerie.Diretor = input.Diretor;
        if (input.Elenco != null)
            getSerie.Elenco = input.Elenco;
        if (input.Pais != null)
            getSerie.Pais = input.Pais;
        if (input?.AnoLancamento != null)
            getSerie.AnoLancamento = input.AnoLancamento;
        if (input?.NumeroTemporadas != null)
            getSerie.NumeroTemporadas = input.NumeroTemporadas;

        await _dbContext.SaveChangesAsync(cancellationToken);

        return getSerie;
    }
}
