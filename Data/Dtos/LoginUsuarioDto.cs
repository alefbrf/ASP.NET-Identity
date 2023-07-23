using System.ComponentModel.DataAnnotations;

namespace Usuarios_API.Data.Dtos
{
    public class LoginUsuarioDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
