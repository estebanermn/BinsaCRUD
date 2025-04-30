using BinsaCRUD.Models;
using BinsaCRUD.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BinsaCRUD.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteDAO _clienteDAO;

        public ClienteController(IClienteDAO clienteDAO)
        {
            _clienteDAO = clienteDAO;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _clienteDAO.GetClientes();
            return View(list);
        }


        public async Task<IActionResult> Form(int id)
        {
            if (id == 0 || id == null)
                return View(new Cliente());

            var cliente = await _clienteDAO.GetClienteById(id);
            if (cliente == null)
                return NotFound();

            return View(cliente);
        }

        // POST: Crear o Editar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Form(int id, Cliente cliente)
        {
            if (!ModelState.IsValid)
                return View(cliente);

            if (id == 0)
                await _clienteDAO.CreateCliente(cliente);
            else
                await _clienteDAO.UpdateCliente(cliente);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await _clienteDAO.GetClienteById(id);
            if(cliente == null)
            {
                return NotFound();
            }
            await _clienteDAO.DeleteCliente(id);
            return RedirectToAction(nameof(Index));    
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
