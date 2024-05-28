using System.Reflection;
using Domain.Entities;
using Flix.Application.InterfaceAdapters;
using Microsoft.EntityFrameworkCore;

namespace Infra.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Filme> Filme => Set<Filme>();
    public DbSet<Livro> Livro => Set<Livro>();
    public DbSet<Serie> Serie => Set<Serie>();
    public DbSet<Usuario> Usuario => Set<Usuario>();
    public DbSet<Comentario> Comentario => Set<Comentario>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<Filme>()
            .ToTable("filme");

        modelBuilder.Entity<Livro>()
            .ToTable("livro");

        modelBuilder.Entity<Serie>()
            .ToTable("serie");

        modelBuilder.Entity<Usuario>()
            .ToTable("usuario");

        modelBuilder.Entity<Comentario>()
            .ToTable("comentario");


        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var output = await base.SaveChangesAsync(cancellationToken);
        return output;
    }

}