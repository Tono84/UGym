using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class UserViewModel
    {
        [Display(Name = "Número de Socio")]
        public string UserName { get; set; }
        public string? Email { get; set; }

        [Display(Name ="Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        public bool RememberLogin { get; set; }
        public string ReturnUrl { get; set; }
    }
}