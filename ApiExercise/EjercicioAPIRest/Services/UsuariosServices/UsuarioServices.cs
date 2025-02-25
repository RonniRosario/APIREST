using Azure.Messaging;
using EjercicioAPIRest.AppValidations;
using EjercicioAPIRest.DB;
using EjercicioAPIRest.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EjercicioAPIRest.Services.UsuariosServices
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly EjercicioAPIRestContext _context;
        public UsuarioServices(EjercicioAPIRestContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> CreateUser(Usuario user)
        {
            try
            {
                var checkEmails = new Validations(_context);
                if (await checkEmails.DuplicateEmails(user))
                {
                    Console.WriteLine("No pueden haber usuarios duplicados");
                    return new BadRequestObjectResult("El correo ya esta en uso");
                   
                }
                await _context.Usuarios.AddAsync(user);
                await _context.SaveChangesAsync();
                return new OkObjectResult("El usuario ha sido creado exitosamente");
            }
            catch (Exception ex)
            {


                return new ObjectResult($"Error: {ex.Message}");
            }

        }

        public async Task<IActionResult> DeleteUser(int id)
        {
            var userFound = await _context.Usuarios.FindAsync(id);
            if (userFound == null) { return new  NotFoundObjectResult("No se encontro el usuario"); }

            _context.Usuarios.Remove(userFound);

            await _context.SaveChangesAsync();
            return new OkObjectResult("Se borro el usuario");
        }

        public async Task<ActionResult<IEnumerable<Usuario>>> Get()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<ActionResult<Usuario>> GetUser(int id)
        {
            var userId = await _context.Usuarios.FindAsync(id);
            if (userId == null) { return new NotFoundObjectResult("No se encontro el usuario"); }

            return new OkObjectResult(userId);
        }

        public async Task<IActionResult> UpdateUser(int id, Usuario user)
        {
            var userFound = await _context.Usuarios.FindAsync(id);
            if (userFound == null) { return new NotFoundObjectResult("No se encontro el usuario"); }
            var checkEmails = new Validations(_context);
            if (await checkEmails.DuplicateEmails(user))
            {
                return new BadRequestObjectResult("No pueden haber emails duplicados");

            }

            userFound.Nombre = user.Nombre;
            userFound.Email = user.Email;
            userFound.FechaNacimiento = user.FechaNacimiento;
            userFound.password = user.password;

            await _context.SaveChangesAsync();

            return new OkObjectResult("Se edito el usuario");
        }
    }
}
