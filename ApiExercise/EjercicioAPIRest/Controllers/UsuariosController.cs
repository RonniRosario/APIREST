using EjercicioAPIRest.AppValidations;
using EjercicioAPIRest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EjercicioAPIRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly DB.EjercicioAPIRestContext _context;
        
        public UsuariosController(DB.EjercicioAPIRestContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("Obtener")]
        public async Task<ActionResult<IEnumerable<Usuario>>> Get() {

            return await _context.Usuarios.ToListAsync();
        }

        [HttpGet]
        [Route("ObtenerId/{id}")]
        public async Task<ActionResult<Usuario>> GetUser(int id)
        {

            var userId = await _context.Usuarios.FindAsync(id);
            if(userId == null) { return NotFound("No se encontro el usuario"); }

            return Ok(userId);
        }

        [HttpPost]
        [Route("Crear")]

        public async Task<ActionResult> CreateUser(Usuario user)
        {
            var checkEmails = new Validations(_context);
            if(await checkEmails.DuplicateEmails(user))
            {
                return BadRequest("No pueden haber emails duplicados");

            }
            await _context.Usuarios.AddAsync(user);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        [Route("Editar/{id}")]
        public async Task <IActionResult> UpdateUser(int id, Usuario user)
        {

            var userFound = await _context.Usuarios.FindAsync(id);
            if (userFound == null) { return NotFound("No se encontro el usuario"); }
            var checkEmails = new Validations(_context);
            if (await checkEmails.DuplicateEmails(user))
            {
                return BadRequest("No pueden haber emails duplicados");

            }

            userFound.Nombre = user.Nombre;
            userFound.Email = user.Email;
            userFound.FechaNacimiento = user.FechaNacimiento;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [Route("Eliminar/{id}")]

        public async Task <IActionResult> DeleteUser(int id)
        {
            var userFound = await _context.Usuarios.FindAsync(id);
            if(userFound == null) { return NotFound("No se encontro el usuario"); }

            _context.Usuarios.Remove(userFound);
            
            await _context.SaveChangesAsync();
            return Ok();
        }








    }
}

