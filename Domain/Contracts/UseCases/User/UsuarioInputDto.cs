using System.ComponentModel.DataAnnotations;

namespace Domain.Contracts.UseCases.User;

public class UsuarioInputDto
{
    public string Username { get; set; } = default!;
    public DateTime DataDeNascimento { get; set; } = default!;
    [DataType(DataType.Password)]
    public string Password{ get; set; } = default!;
    [Compare("Password")]
    public string RePassword { get; set; } = default!;

}
