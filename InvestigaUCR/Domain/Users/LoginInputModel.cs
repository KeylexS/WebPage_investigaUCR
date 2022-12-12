using System.ComponentModel.DataAnnotations;

namespace Domain.Users
{
    public class LoginInputModel
    {
        [Required(ErrorMessage = "Debe ingresar un correo")]
        [EmailAddress(ErrorMessage = "El email ingresado no es válido")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Debe ingresar una contraseña")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name = "Recordarme")]
        public bool RememberMe { get; set; }
    }
}
