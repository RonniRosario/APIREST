using EjercicioAPIRest.AppValidations;
using EjercicioAPIRest.Models;
using EjercicioAPIRest.Services.UsuariosServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EjercicioAPIRest.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioServices _services;
        
        public UsuariosController(IUsuarioServices services)
        {
            _services = services;
        }


        [HttpGet]
        [Route("Obtener")]
        public Task<ActionResult<IEnumerable<Usuario>>> Get()
            => _services.Get();

        [HttpGet]
        [Route("ObtenerId/{id}")]
        public  Task<ActionResult<Usuario>> GetUser(int id)
            => _services.GetUser(id);
        

        [HttpPost]
        [Route("Crear")]
        

        public Task<ActionResult> CreateUser(Usuario user)
            => _services.CreateUser(user);
        

        [HttpPut]
        [Route("Editar/{id}")]
        
        public Task <IActionResult> UpdateUser(int id, Usuario user)
            => _services.UpdateUser(id, user);


        [HttpDelete]
        [Route("Eliminar/{id}")]
         

        public Task<IActionResult> DeleteUser(int id)
            => _services.DeleteUser(id);
        
    }
}

