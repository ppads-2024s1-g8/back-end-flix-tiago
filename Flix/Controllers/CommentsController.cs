using Application.UseCases.Comentarios;
using Domain.Contracts.UseCases.Comentario;
using Microsoft.AspNetCore.Mvc;

namespace Flix.Controllers;

[ApiController]
[Route("[controller]")]
public class CommentsController : ControllerBase
{
    private readonly ComentarioUseCase comentarioUseCase;

    [HttpPost("Comentarios")]
    public async Task<IActionResult> RegisterUser(ComentarioDTO input, CancellationToken cancellationToken)
    {
        var usuario = await comentarioUseCase.PostComentario(input, cancellationToken);

        return Ok(usuario);
    }

}
