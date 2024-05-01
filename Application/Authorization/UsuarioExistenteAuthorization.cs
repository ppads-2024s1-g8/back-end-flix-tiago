using Microsoft.AspNetCore.Authorization;

namespace Application.Authorization;

public class UsuarioExistenteAuthorization : AuthorizationHandler<UsuarioExistente>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UsuarioExistente requirement)
    {
        throw new NotImplementedException();
    }
}
