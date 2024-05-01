namespace Domain.Contracts.UseCases.User;

public interface IUsuarioUseCase
{
    Task<string> RegisterUser(UsuarioInputDto dto, CancellationToken cancellationToken);
    Task<string> Login(LoginUsuarioDto dtoLogin, CancellationToken cancellationToken);
    Task<string> Avaliacao(AvaliacaoUsuarioDto avaliacaoUsuarioDto, CancellationToken cancellationToken);   
}
