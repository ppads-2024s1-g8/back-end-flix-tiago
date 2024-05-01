namespace Domain.Contracts.UseCases.User;


public class LoginUsuarioDto
{
    public string Username { get; set; } = default!;
    public string Password { get; set; } = default!;
}
