using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;


public class Usuario
{
    public Usuario(string username, DateTime dataDeNascimento, string password, string rePassword)
    {
        Username = username;
        DataDeNascimento = dataDeNascimento;
        Password = password;
        RePassword = rePassword;
    }
    [Key]
    public int Id { get; init; }
    public string Username { get; set; } = default!;
    public DateTime DataDeNascimento { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string RePassword { get; set; } = default!;



}