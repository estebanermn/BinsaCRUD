using BinsaCRUD.Models;

namespace BinsaCRUD.Repository.Interface
{
    public interface IContactoDAO
    {
        public Task<ContactoCliente> GetContactoById(int contactoId);
        public Task CreateByCliente(ContactoCliente contacto);
        public Task UpdateContactoByCliente(ContactoCliente contacto);
        public Task DeleteContactoByCliente(int contactoId);

    }
}
