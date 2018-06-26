using System.ComponentModel.DataAnnotations;

namespace Vitechd.Models
{
    public class MailModels
    {
        [Key]
        public int Id { get; set; }
        [Required, Display(Name = "Nombre")]
        public string Name { get; set; }
        [Required, Display(Name = "Correo"), EmailAddress]
        public string Email { get; set; }
        public string Telephone { get; set; }
        [Required]
        public string Message { get; set; }
    }
}