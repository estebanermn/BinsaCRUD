using BinsaCRUD.Models;

namespace BinsaCRUD.Repository.Interface
{
    public interface IClienteDAO
    {
        public Task<IEnumerable<Cliente>> GetClientes();
        public Task<Cliente> GetClienteById(int clienteId);
        public Task CreateCliente(Cliente cliente);
        public Task UpdateCliente(Cliente cliente);
        public Task DeleteCliente(int clienteId);
        

    }
}
