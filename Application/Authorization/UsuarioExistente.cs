using Microsoft.AspNetCore.Authorization;

namespace Application.Authorization;

public class UsuarioExistente : IAuthorizationRequirement
{
    public UsuarioExistente(bool usuarioExistente)
    {
        UsuarioExistenteValidator = usuarioExistente;
    }
    public bool UsuarioExistenteValidator { get; set; }
}
