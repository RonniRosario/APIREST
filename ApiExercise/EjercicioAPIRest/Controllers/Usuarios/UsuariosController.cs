using EjercicioAPIRest.AppValidations;
using EjercicioAPIRest.Models;
using EjercicioAPIRest.Services.LogUser;
using EjercicioAPIRest.Services.UsuariosServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EjercicioAPIRest.Controllers.Usuarios
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ICrudServices<Usuario> _services;
        private readonly ILogUser<Usuario> _logServices;

        public UsuariosController(ICrudServices<Usuario> services, ILogUser<Usuario> logServices)
        {
            _services = services;
            _logServices = logServices;
        }


        [HttpGet]
        [Route("Obtener")]
        public Task<ActionResult<IEnumerable<Usuario>>> Get()
            => _services.GetAll();

        [HttpGet]
        [Route("ObtenerId/{id}")]
        public Task<ActionResult<Usuario>> GetUser(int id)
            => _services.Get(id);

        [HttpGet]
        [Route("ObtenerLogs")]
        public Task<ActionResult<Usuario>> ReadLog()=>
            _logServices.ReadLog();


        [HttpPost]
        [Route("Crear")]


        public Task<ActionResult> CreateUser(Usuario user)
            => _services.Create(user);


        [HttpPut]
        [Route("Editar/{id}")]

        public Task<IActionResult> UpdateUser(int id, Usuario user)
            => _services.Update(id, user);


        [HttpDelete]
        [Route("Eliminar/{id}")]


        public Task<IActionResult> DeleteUser(int id)
            => _services.Delete(id);

    }
}

