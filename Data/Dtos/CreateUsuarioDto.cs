using System.ComponentModel.DataAnnotations;

namespace Usuarios_API.Data.Dtos;

public class CreateUsuarioDto
{
    [Required]
    public string Username { get; set; }
    [Required]
    public DateTime DataNascimento { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Required]
    [Compare("Password")]
    public string PasswordConfirmation { get; set; }
}
