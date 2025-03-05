using EjercicioAPIRest.Models;
using EjercicioAPIRest.Services.UsuariosServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EjercicioAPIRest.Controllers.Proveedores
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly ICrudServices<Proveedor> _services;

        public ProveedorController(ICrudServices<Proveedor> services)
        {
            _services = services;
        }

        [HttpGet]
        [Route("Obtener")]
        public Task<ActionResult<IEnumerable<Proveedor>>> GetAll()=>
            _services.GetAll();

        [HttpGet]
        [Route("ObtenerId/{id}")]
        public Task<ActionResult<Proveedor>> GetProveedor(int id ) =>
            _services.Get(id);

        [HttpPost]
        [Route("Crear")]
        public Task <ActionResult> CreateProvider(Proveedor proveedor)=>
            _services.Create(proveedor);

        [HttpPut]
        [Route("Editar/{id}")]
        public Task<IActionResult> UpdateProvider(int id, Proveedor proveedor)=>
            _services.Update(id,proveedor);

        [HttpDelete]
        [Route("Eliminar/{id}")]
        public Task<IActionResult> DeleteProvider(int id) =>
            _services.Delete(id);
    }
}
