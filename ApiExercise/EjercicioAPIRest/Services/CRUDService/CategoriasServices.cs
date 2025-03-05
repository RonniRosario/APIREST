
using EjercicioAPIRest.DB;
using EjercicioAPIRest.Models;
using EjercicioAPIRest.Services.UsuariosServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace EjercicioAPIRest.Services.CRUDServices
{
    public class CategoriasServices : ICrudServices<Categoria>
    {
        private readonly EjercicioAPIRestContext _context;
        public CategoriasServices(EjercicioAPIRestContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> Create(Categoria item)
        {
            var newCategory = new Categoria
            {
                IdCategoria = item.IdCategoria,
                Nombre = item.Nombre
            };
            if (newCategory == null)
            {
                return new BadRequestObjectResult("La categoria no puede ser nula");
            }
            await _context.Categorias.AddAsync(newCategory);
            await _context.SaveChangesAsync();
            return new OkObjectResult("La categoria ha sido creado exitosamente");

        }

        public async Task<IActionResult> Delete(int id)
        {
            var categoryFound = await _context.Categorias.FindAsync(id);
            if (categoryFound == null) { return new NotFoundObjectResult("No se encontro La categoria"); }

            _context.Categorias.Remove(categoryFound);

            await _context.SaveChangesAsync();
            return new OkObjectResult("Se borro la categoria");
        }

        public async Task<ActionResult<IEnumerable<Categoria>>> GetAll()
        {
            return await _context.Categorias.ToListAsync();

        }

        public async Task<ActionResult<Categoria>> Get(int id)
        {
            var categoryId = await _context.Categorias.FindAsync(id);
            if (categoryId == null) { return new NotFoundObjectResult("No se encontro la categoria"); }

            return new OkObjectResult(categoryId);
        }

        public async Task<IActionResult> Update(int id, Categoria item)
        {
            var categoryFound = await _context.Categorias.FindAsync(id);
            if (categoryFound == null) { return new NotFoundObjectResult("No se encontro la categoria"); }

            categoryFound.IdCategoria = item.IdCategoria;
            categoryFound.Nombre = item.Nombre;

            await _context.SaveChangesAsync();

            return new OkObjectResult("Se edito la categoria");
        }
    }
}
