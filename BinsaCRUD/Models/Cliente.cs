using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace BinsaCRUD.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required, MaxLength(40)]
        public string Nombre { get; set; }

        [MaxLength(40)]
        public string Domicilio { get; set; }

        [MaxLength(5)]
        public string CodigoPostal { get; set; }

        [MaxLength(40)]
        public string Poblacion { get; set; }

        [ValidateNever]
        //public virtual ICollection<ContactoCliente> Contactos { get; set; }
        public virtual ICollection<ContactoCliente> Contactos { get; set; } = new List<ContactoCliente>();

    }
}
