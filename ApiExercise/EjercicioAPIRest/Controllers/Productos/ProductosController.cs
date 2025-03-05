using EjercicioAPIRest.Models;
using EjercicioAPIRest.Services.ProductQueries;
using EjercicioAPIRest.Services.UsuariosServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EjercicioAPIRest.Controllers.Productos
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ICrudServices<Producto> _services;
        private readonly IProductsInfo<Producto> _productsInfo;

        public ProductosController(ICrudServices<Producto> services, IProductsInfo<Producto> productsInfo)
        {
            _services = services;
            _productsInfo = productsInfo;
        }

        [HttpGet]
        [Route("Obtener")]
        public Task<ActionResult<IEnumerable<Producto>>> GetAll() =>
            _services.GetAll();

        [HttpGet]
        [Route("ProductoStats")]
        public Task<ActionResult<Producto>> ProductStats()=>
            _productsInfo.ProductStats();

        [HttpGet]
        [Route("CategoriaProducto")]
        public  Task<ActionResult<Producto>> CategoryProducts()=>
            _productsInfo.CategoryProducts();

        [HttpGet]
        [Route("ProveedorProducto")]
        public Task<ActionResult<Producto>> ProviderProducts()=>
            _productsInfo.ProviderProducts();

        [HttpGet]
        [Route("ContarProductos")]
        public Task<ActionResult<Producto>> ProductsQuantity()=>
            _productsInfo.ProductsQuantity();

        [HttpGet]
        [Route("ObtenerId/{id}")]
        public Task<ActionResult<Producto>> GetProducto(int id) =>
            _services.Get(id);

        [HttpPost]
        [Route("Crear")]
        public Task<ActionResult> CreateProduct(Producto producto)=>
            _services.Create(producto);

        [HttpPut]
        [Route("Editar/{id}")]
        public Task<IActionResult> UpdateProduct(int id, Producto producto)=>
            _services.Update(id, producto);

        [HttpDelete]
        [Route("Eliminar/{id}")]
        public Task<IActionResult> DeleteProduct(int id) =>
            _services.Delete(id);
    }
}
