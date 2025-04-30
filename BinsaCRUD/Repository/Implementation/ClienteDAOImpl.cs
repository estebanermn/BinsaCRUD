using BinsaCRUD.Models;
using BinsaCRUD.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BinsaCRUD.Repository.Implementation
{
    public class ClienteDAOImpl : IClienteDAO
    {
        private readonly AppDbContext _appDbContext;
        public ClienteDAOImpl(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            return await _appDbContext.Clientes
                .Include(x => x.Contactos)
                .ToListAsync();
        }

        public async Task<Cliente> GetClienteById(int clienteId)
        {
            return await _appDbContext.Clientes
                .Include(x => x.Contactos)
                .FirstAsync(x => x.Id == clienteId);
        }

        public async Task CreateCliente(Cliente cliente)
        {
            await _appDbContext.Clientes.AddAsync(cliente);
            await _appDbContext.SaveChangesAsync();
        }


        public async Task UpdateCliente(Cliente cliente)
        {
            _appDbContext.Entry(cliente).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
        }
        public async Task DeleteCliente(int clienteId)
        {
            var cliente = await _appDbContext.Clientes.FirstOrDefaultAsync(x => x.Id == clienteId);
            if (cliente != null)
            {
                _appDbContext.Clientes.Remove(cliente);
                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}
