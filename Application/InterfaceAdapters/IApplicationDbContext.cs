using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flix.Application.InterfaceAdapters;

public interface IApplicationDbContext
{
    DbSet<Filme> Filme { get; }
    DbSet<Livro> Livro { get; }
    DbSet<Serie> Serie { get; }
    DbSet<Usuario> Usuario { get; }
    
    DbSet<Comentario> Comentario { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

}
