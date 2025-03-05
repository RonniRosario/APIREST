using EjercicioAPIRest.Models;
using EjercicioAPIRest.Services.UsuariosServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EjercicioAPIRest.Controllers.Categorias
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICrudServices<Categoria> _services;

        public CategoriasController(ICrudServices<Categoria> services)
        {
            _services = services;
        }

        [HttpGet]
        [Route("Obtener")]
        public Task<ActionResult<IEnumerable<Categoria>>> GetAll()=>
            _services.GetAll();

        [HttpGet]
        [Route("ObtenerId/{id}")]
        public Task<ActionResult<Categoria>> GetCategoria(int id)=>
            _services.Get(id);

        [HttpPost]
        [Route("Crear")]
        public Task<ActionResult> CreateCategoria(Categoria categoria)=>
            _services.Create(categoria);

        [HttpPut]
        [Route("Editar/{id}")]
        public Task<IActionResult> UpdateCategoria(int id,Categoria categoria) =>
            _services.Update(id,categoria);

        [HttpDelete]
        [Route("Eliminar/{id}")]
        public Task<IActionResult> DeleteCategoria(int id)=>
            _services.Delete(id);
    }
}
