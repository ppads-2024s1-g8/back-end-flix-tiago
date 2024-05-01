namespace Domain.Entities;


public static class Authorization
{
    public static bool UsuarioExistente { get; set; } = false;

    public static void SetUsuarioExistente(bool usuarioExistente)
    {
        UsuarioExistente = usuarioExistente;
    }
}
