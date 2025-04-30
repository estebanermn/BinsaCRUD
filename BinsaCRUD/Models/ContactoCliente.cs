using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BinsaCRUD.Models
{
    public class ContactoCliente
    {
        public int Id { get; set; }

        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }

        [MaxLength(40)]
        public string Nombre { get; set; }

        [MaxLength(40)]
        public string Telefono { get; set; }

        [MaxLength(40)]
        public string Email { get; set; }
        [ValidateNever]
        public virtual Cliente Cliente { get; set; }
    }
}
