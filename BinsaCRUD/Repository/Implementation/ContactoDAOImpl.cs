using BinsaCRUD.Models;
using BinsaCRUD.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BinsaCRUD.Repository.Implementation
{
    public class ContactoDAOImpl : IContactoDAO
    {
        private readonly AppDbContext _appDbContext;
        public ContactoDAOImpl(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ContactoCliente> GetContactoById(int contactoId)
        {
            return await _appDbContext.ContactosCliente.FirstAsync(x => x.Id == contactoId);
        }

        public async Task CreateByCliente(ContactoCliente contacto)
        {
            await _appDbContext.ContactosCliente.AddAsync(contacto);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateContactoByCliente(ContactoCliente contacto)
        {
            _appDbContext.Entry(contacto).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteContactoByCliente(int contactoId)
        {
            var contacto = await _appDbContext.ContactosCliente.FirstOrDefaultAsync(x => x.Id == contactoId);
            if (contacto != null)
            {
                _appDbContext.ContactosCliente.Remove(contacto);
                await _appDbContext.SaveChangesAsync();
            }
        }

    }
}
