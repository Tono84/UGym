using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models.FEAuthentication
{
    public class Register
    {
        [Display(Name = "Número de Socio")]
        [Required(ErrorMessage = "El número de socio es requerido")]
        public string? Username { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Password is Required")]
        [PasswordPropertyText]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name = "Correo Electronico")]
        [EmailAddress]
        [Required(ErrorMessage = "El correo es obligatorio")]
        public string? Email { get; set; }

        [Display(Name = "Número de Cédula")]
        [Required(ErrorMessage = "El número de cédula es obligatorio")]
        public string? Cedula { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        public DateTime? Birthday { get; set; }

        [Display(Name = "Número Teléfonico")]
        [Required(ErrorMessage = "El número teléfonico es obligatorio")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Nombre Completo (Incluir ambos apellidos)")]
        [Required(ErrorMessage = "El nombre es requerido")]
        public string? Name { get; set; }

        [Display(Name = "Genero")]
        [Required(ErrorMessage = "El genero es requerido")]
        public string? Gender { get; set; }

        [Display(Name = "Profesión")]
        [Required(ErrorMessage = "La profesión es requerida")]
        public string? Ocupation { get; set; }

        [Display(Name = "¿Como supiste de nosotros?")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string? KnowGym { get; set; }

    }
}

