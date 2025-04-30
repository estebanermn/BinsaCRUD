using BinsaCRUD.Models;
using BinsaCRUD.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BinsaCRUD.Controllers
{
    public class ContactoController : Controller
    {
        private readonly IContactoDAO _contactoDAO;
        private readonly IClienteDAO _clienteDAO;

        public ContactoController(IContactoDAO contactoDAO, IClienteDAO clienteDAO) {
            
            _contactoDAO = contactoDAO;
            _clienteDAO = clienteDAO;
        }

        // GET: Contactos?clienteId=5
        public async Task<IActionResult> Index(int clienteId)
        {
            var cliente = await _clienteDAO.GetClienteById(clienteId);

            if (cliente == null)
                return NotFound();

            ViewBag.ClienteNombre = cliente.Nombre;
            ViewBag.ClienteId = cliente.Id;
            return View(cliente.Contactos);
        }

        // GET: Contactos/Form?clienteId=5&id=3
        public async Task<IActionResult> Form(int clienteId, int id)
        {
            if (id == 0 || id == null)
                return View(new ContactoCliente { ClienteId = clienteId });

            var contacto = await _contactoDAO.GetContactoById(id);
            if (contacto == null)
                return NotFound();

            return View(contacto);
        }


        // POST: Crear o Editar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Form(ContactoCliente contacto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ClienteId = contacto.ClienteId;
                return View(contacto);
            }
                
            if (contacto.Id == 0)
                await _contactoDAO.CreateByCliente(contacto);
            else
                await _contactoDAO.UpdateContactoByCliente(contacto);

            return RedirectToAction(nameof(Index), new { clienteId = contacto.ClienteId});
        }

        public async Task<IActionResult> Delete(int id)
        {
            var contacto = await _contactoDAO.GetContactoById(id);
            if (contacto == null)
            {
                return NotFound();
            }
            await _contactoDAO.DeleteContactoByCliente(id);
            return RedirectToAction(nameof(Index), new { clienteId = contacto.ClienteId });
        }

        public IActionResult BackPage(int id)
        {
            return RedirectToAction(nameof(Index), new { clienteId = id });
        }
    }
}
