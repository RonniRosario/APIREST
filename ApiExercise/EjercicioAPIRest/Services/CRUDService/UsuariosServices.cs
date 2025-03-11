
using EjercicioAPIRest.AppValidations;
using EjercicioAPIRest.DB;
using EjercicioAPIRest.JWT;
using EjercicioAPIRest.Models;
using EjercicioAPIRest.Services.LogUser;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.Json;

namespace EjercicioAPIRest.Services.UsuariosServices
{
    public class UsuariosServices : ICrudServices<Usuario>, ILogUser<Usuario>
    {
        private readonly EjercicioAPIRestContext _context;
        private readonly Utilities _utilities;
        private string filePath = @"C:\Users\ronni\source\repos\APIREST\ApiExercise\EjercicioAPIRest\Services\LogUser\UserLogs.txt";

        public UsuariosServices(EjercicioAPIRestContext context, Utilities utilities)
        {
            _context = context;
            _utilities = utilities;
        }

        public async Task<ActionResult> Create(Usuario user)
        {
            try
            {
                //Crear el usuario y encriptar la contraseña
                var newUser = new Usuario
                {
                    Nombre = user.Nombre,
                    Email = user.Email,
                    FechaNacimiento = user.FechaNacimiento,
                    password = _utilities.encryptSHA256(user.password)
                };
                var checkEmails = new Validations(_context);
                if (await checkEmails.DuplicateEmails(user))
                {
                    Console.WriteLine("No pueden haber usuarios duplicados");
                    return new BadRequestObjectResult("El correo ya esta en uso");

                }
                await _context.Usuarios.AddAsync(newUser);
                await _context.SaveChangesAsync();

               
                //Crear el log
                

                using (FileStream oFs = File.Open(filePath,FileMode.Append, FileAccess.Write))
                {

                        var options = new JsonSerializerOptions { WriteIndented = true };
                        var userLogSerialized = JsonSerializer.Serialize(user, options);

                        Byte[] logUserInfoBytes = new UTF8Encoding(true).GetBytes(userLogSerialized);

                        await oFs.WriteAsync(logUserInfoBytes, 0, logUserInfoBytes.Length);
                }


                return new OkObjectResult("El usuario ha sido creado exitosamente");
            }
            catch (Exception ex)
            {


                return new ObjectResult($"Error: {ex.Message}");
            }

        }

        public async Task<IActionResult> Delete(int id)
        {
            var userFound = await _context.Usuarios.FindAsync(id);
            if (userFound == null) { return new  NotFoundObjectResult("No se encontro el usuario"); }

            _context.Usuarios.Remove(userFound);

            await _context.SaveChangesAsync();
            return new OkObjectResult("Se borro el usuario");
        }

        public async Task<ActionResult<IEnumerable<Usuario>>> GetAll()=>
             await _context.Usuarios.ToListAsync();
        
      
        public async Task<ActionResult<Usuario>> Get(int id)
        {
            var userId = await _context.Usuarios.FindAsync(id);
            if (userId == null) { return new NotFoundObjectResult("No se encontro el usuario"); }

            return new OkObjectResult(userId);
        }

        public async Task<IActionResult> Update(int id, Usuario user)
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

        public async Task<ActionResult<Usuario>> ReadLog()
        {
            if (!File.Exists(filePath)){
                return new NotFoundObjectResult("No hay logs disponinles");
            }
            string jsonLogs = await File.ReadAllTextAsync(filePath);

            
            return new ObjectResult(jsonLogs);
        }
    }
}
