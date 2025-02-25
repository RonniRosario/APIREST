using EjercicioAPIRest.Models;
using Microsoft.AspNetCore.Mvc;

namespace EjercicioAPIRest.Services.UsuariosServices
{
    public interface IUsuarioServices
    {
        Task<ActionResult<IEnumerable<Usuario>>> Get();
        Task<ActionResult<Usuario>> GetUser(int id);
        Task<ActionResult> CreateUser(Usuario user);
        Task<IActionResult> DeleteUser(int id);
        Task<IActionResult> UpdateUser(int id, Usuario user);
    }
}
