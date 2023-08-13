using System.ComponentModel.DataAnnotations;

namespace ConteoRecaudo.API.Models
{
    public class Register
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        public string FirstName { get; set; }
       
        [Required(ErrorMessage = "El apellido es requerido")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "La contraseña es requerida")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "El correo es requerido")]
        public string Email { get; set; }
    }
}
