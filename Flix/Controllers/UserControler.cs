using Domain.Contracts.UseCases.User;
using Microsoft.AspNetCore.Mvc;

namespace Flix.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUsuarioUseCase _UsuarioUseCase;

    public UserController(IUsuarioUseCase createUser)
    {
        _UsuarioUseCase = createUser;
    }

    [HttpPost("cadastro")]
    public async Task<IActionResult> RegisterUser(UsuarioInputDto input, CancellationToken cancellationToken)
    {
        var usuario = await _UsuarioUseCase.RegisterUser(input, cancellationToken);

        return Ok(
                new
                {
                    Username = usuario
                });
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginUsuarioDto input, CancellationToken cancellationToken)
    {
        await _UsuarioUseCase.Login(input, cancellationToken);
        return Ok("Usuário Autenticado");

    }
    [HttpPost("avaliacoes")]
    public async Task<IActionResult> Avaliacoes(AvaliacaoUsuarioDto input, CancellationToken cancellationToken)
    {
        await _UsuarioUseCase.Avaliacao(input, cancellationToken);
        return Ok("Avalição Feita");

    }

}
