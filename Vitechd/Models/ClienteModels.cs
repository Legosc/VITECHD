using System.ComponentModel.DataAnnotations;

namespace Vitechd.Models
{
    public class ClienteModels
    {
        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Tipo de Identificacion")]
        public string TipoIdentificacion { get; set; }
        [Required]
        [Display(Name = "Identificacion")]
        public string NumeroIdentificacion { get; set; }
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }
        [Display(Name = "Correo")]
        public string Email { get; set; }
    }
}
