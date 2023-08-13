using System.ComponentModel.DataAnnotations;

namespace ConteoRecaudo.Infraestructure.Models
{
    public class AuthenticateRequest
    {
        [Required(ErrorMessage = "El usuario es requerido")]
        [MinLength(4, ErrorMessage = "El usuario no debe tener menos de 4 caracteres.")]
        [MaxLength(20, ErrorMessage = "El usuario no debe tener mas de 20 caracteres.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida.")]
        [MaxLength(50, ErrorMessage = "La contraseña no debe tener mas de 50 caracteres.")]
        [MinLength(4, ErrorMessage = "La contraseña no debe tener menos de 4 caracteres.")]
        public string Password { get; set; }
    }
}
