using EjercicioAPIRest.DB;
using EjercicioAPIRest.Models;
using EjercicioAPIRest.Services.UsuariosServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Contracts;

namespace EjercicioAPIRest.Services.CRUDService
{
    public class ProveedorServices : ICrudServices<Proveedor>
    {
        private readonly EjercicioAPIRestContext _context;
        public ProveedorServices(EjercicioAPIRestContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> Create(Proveedor item)
        {
            var newProvider = new Proveedor
            {
                IdProveedor = item.IdProveedor,
                Contacto = item.Contacto,
                Nombre = item.Nombre,
            };

            if (newProvider == null) { return new BadRequestObjectResult("El producto no puede ser nulo"); }

            await _context.Proveedor.AddAsync(newProvider);
            await _context.SaveChangesAsync();
            return new OkObjectResult("El proveedor ha sido creado exitosamente");

        }

        public async Task<IActionResult> Delete(int id)
        {
            var providerFound = await _context.Proveedor.FindAsync(id);
            if (providerFound == null) { return new NotFoundObjectResult("El proveedor no existe"); }

            _context.Proveedor.Remove(providerFound);

            await _context.SaveChangesAsync();
            return new ObjectResult("Se borro el proveedor");

        }

        public async Task<ActionResult<Proveedor>> Get(int id)
        {
            var providerFound = await _context.Proveedor.FindAsync(id);
            if (providerFound == null) { return new NotFoundObjectResult("El proveedor no existe"); }

            return new ObjectResult(providerFound);
        }

        public async Task<ActionResult<IEnumerable<Proveedor>>> GetAll() =>

             await _context.Proveedor.ToListAsync();


        public async Task<IActionResult> Update(int id, Proveedor item)
        {
            var providerFound = await _context.Proveedor.FindAsync(id);
            if (providerFound == null) { return new NotFoundObjectResult("El proveedor no existe"); }


            providerFound.IdProveedor = item.IdProveedor;
            providerFound.Contacto = item.Contacto;
            providerFound.Nombre = item.Nombre;

            await _context.SaveChangesAsync();

            return new ObjectResult("Se edito el proveedor");
        }
    }
}
