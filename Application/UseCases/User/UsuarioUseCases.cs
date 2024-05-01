using Domain.Contracts.UseCases.User;
using Domain.Entities;
using Flix.Application.InterfaceAdapters;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.User;

public class UsuarioUseCases : IUsuarioUseCase
{
    private readonly IApplicationDbContext _dbContext;
    private readonly TokenUserCase _TokenGenerator;

    public UsuarioUseCases(IApplicationDbContext dbContext, TokenUserCase tokenGenerator)
    {
        _dbContext = dbContext;
        _TokenGenerator = tokenGenerator;
    }

    public async Task<string> RegisterUser(UsuarioInputDto dto, CancellationToken cancellationToken)
    {
        var newUser = new Usuario(dto.Username, dto.DataDeNascimento, dto.Password, dto.RePassword);

        await _dbContext.Usuario.AddAsync(newUser, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return newUser.Username;
    }

    public async Task<string> Login(LoginUsuarioDto dtoLogin, CancellationToken cancellationToken)
    {
        var usuarioExistente = await _dbContext.Usuario.FirstOrDefaultAsync(u => u.Username == dtoLogin.Username, cancellationToken);

        if (usuarioExistente == null)
        {
            throw new ApplicationException("Usuario nao autenticado");
        }

        if (usuarioExistente.Password != dtoLogin.Password)
        {
            throw new ApplicationException("Usuario nao autenticado");
        }

        var token = _TokenGenerator.GenerateToken(usuarioExistente);
        Domain.Entities.Authorization.SetUsuarioExistente(true);
        return token;
    }

    public async Task<string> Avaliacao(AvaliacaoUsuarioDto avaliacaoUsuarioDto, CancellationToken cancellationToken)
    {
        if(avaliacaoUsuarioDto.Tipo == "Filme")
        {
            var filme = new Filme();
            filme.SetAvaliação();
            await _dbContext.Filme.AddAsync(filme, cancellationToken);

        }

        if (avaliacaoUsuarioDto.Tipo == "Serie")
        {
            var serie = new Serie();
            serie.SetAvaliação();
            await _dbContext.Serie.AddAsync(serie, cancellationToken);
        }

        if (avaliacaoUsuarioDto.Tipo == "Livro")
        {
            var livro = new Livro();
            livro.SetAvaliação();
            await _dbContext.Livro.AddAsync(livro, cancellationToken);
        }


        await _dbContext.SaveChangesAsync(cancellationToken);
        return string.Empty;
    }
}
