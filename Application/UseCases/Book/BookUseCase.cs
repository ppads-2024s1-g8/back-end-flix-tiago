using Domain.Entities;
using Domain.Contracts.UseCases.Book;
using Domain.Contracts.UseCases.Film;
using Flix.Application.InterfaceAdapters;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Book;


public class BookUseCase : IBookUseCase
{
    private readonly IApplicationDbContext _dbContext;

    public BookUseCase(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<string> CreateAsync(BookInputDto input, CancellationToken cancellationToken)
    {
        var newLivro = new Livro(input.Titulo,
                               input.Autor,
                               input.Editora,
                               input.Pais,
                               input.AnoLancamento);

        await _dbContext.Livro.AddAsync(newLivro, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return newLivro.Titulo;
    }

    public async Task<List<Livro>> GetAllAsync(CancellationToken cancellationToken)
    {
        var allBook = await _dbContext.Livro.ToListAsync();
        return allBook;
    }

    public async Task<Livro> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var idLivro = await _dbContext.Livro.FirstOrDefaultAsync(livro => livro.Id == id);

        return idLivro!;
    }

    public async Task<Livro> DeleteByIdAsync(int id, CancellationToken cancellationToken)
    {
        var deletedLivro = await _dbContext.Livro.FirstOrDefaultAsync(livro => livro.Id == id);

        _dbContext.Livro.Remove(deletedLivro!);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return deletedLivro!;
    }

    public async Task<Livro> PutByIdAsync(BookInputDto livro, int id, CancellationToken cancellationToken)
    {
        var getLivro = await _dbContext.Livro.FirstOrDefaultAsync(l => l.Id == id);


        if (getLivro == null)
        {
            throw new Exception("Filme não encontrado");
        }

        if (livro.Titulo != null)
            getLivro.Titulo = livro.Titulo;
        if (livro.Autor != null)
            getLivro.Autor = livro.Autor;
        if (livro.Editora != null)
            getLivro.Editora = livro.Editora;
        if (livro.Pais != null)
            getLivro.Pais = livro.Pais;
        if (livro?.AnoLancamento != null)
            getLivro.AnoLancamento = livro.AnoLancamento;

        await _dbContext.SaveChangesAsync(cancellationToken);

        return getLivro;
    }
}
