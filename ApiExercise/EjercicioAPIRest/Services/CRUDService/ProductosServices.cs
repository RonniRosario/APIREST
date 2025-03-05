using EjercicioAPIRest.DB;
using EjercicioAPIRest.Models;
using EjercicioAPIRest.Services.ProductQueries;
using EjercicioAPIRest.Services.UsuariosServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EjercicioAPIRest.Services.CRUDService
{
    public class ProductosServices : ICrudServices<Producto>, IProductsInfo<Producto>
    {
        private readonly EjercicioAPIRestContext _context;
        public ProductosServices(EjercicioAPIRestContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> Create(Producto item)
        {
            var newProduct = new Producto
            {
                Id = item.Id,
                Nombre = item.Nombre,
                Precio = item.Precio,
                Stock = item.Stock,
                IdCategoria = item.IdCategoria,
                IdProveedor = item.IdProveedor,
            };

            if (newProduct == null)
                return new BadRequestObjectResult("El producto no puede ser nulo");


            await _context.Productos.AddAsync(newProduct);
            await _context.SaveChangesAsync();
            return new OkObjectResult("El producto ha sido creado exitosamente");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var productFound = await _context.Productos.FindAsync(id);
            if (productFound == null) { return new NotFoundObjectResult("El producto no existe"); }

            _context.Productos.Remove(productFound);

            await _context.SaveChangesAsync();
            return new ObjectResult("Se borro el producto");
        }

        public async Task<ActionResult<Producto>> Get(int id)
        {
            var productId = await _context.Productos.FindAsync(id);
            if (productId == null) { return new NotFoundObjectResult("No se encontro el producto"); }

            return new ObjectResult(productId);
        }

        public async Task<ActionResult<IEnumerable<Producto>>> GetAll() =>
             await _context.Productos.ToListAsync();

        public async Task<ActionResult<Producto>> ProductStats()
        {
            var maxProductPrice = await (from p in _context.Productos
                                        orderby p.Precio descending
                                        select p).FirstOrDefaultAsync();

            var minProductPrice = await (from p in _context.Productos
                                         orderby p.Precio ascending
                                         select p).FirstOrDefaultAsync();

            var sumProducts = await (from p in _context.Productos
                                     select p.Precio).SumAsync();

            var avgProducts = await (from p in _context.Productos
                                     select p.Precio).AverageAsync();

            return new ObjectResult($"El precio del producto mas alto es {maxProductPrice.Nombre}, su precio es {maxProductPrice.Precio}\n" +
                $" El precio del producto mas bajo es {minProductPrice.Nombre}, su precio es {minProductPrice.Precio}\n" +
                $"La suma del precio de todos los productos es {sumProducts}\n" +
                $"El promedio del precio de todos los productos es {avgProducts}");

        }

        public async Task<ActionResult<Producto>> CategoryProducts()
        {
            var categoryProducts = await (from p in _context.Productos
                                          join c in _context.Categorias
                                          on p.IdCategoria equals c.IdCategoria
                                          where c.Nombre.Equals("Tecnologia")
                                          select new
                                          {
                                            p.Id,
                                            p.Nombre,
                                            p.Precio,
                                            Categoria = c.Nombre,
                                            p.Stock

                                          }).ToListAsync();
                                          

            
            return new ObjectResult(categoryProducts);
        }

        public async Task<ActionResult<Producto>> ProviderProducts()
        {
            var providerProducts = await (from pr in _context.Productos
                                          join p in _context.Proveedor
                                          on pr.IdProveedor equals p.IdProveedor
                                          where p.IdProveedor.Equals(1)
                                          select new
                                          {
                                              pr.Id,
                                              pr.Nombre,
                                              pr.Precio,
                                              Proveedor = p.Nombre,
                                              p.Contacto,
                                              pr.Stock

                                          }).ToListAsync();



            return new ObjectResult(providerProducts);
        }

        public async Task<ActionResult<Producto>> ProductsQuantity()
        {
            var productsQuantity = await _context.Productos.CountAsync();

            return new OkObjectResult($"La cantidad de productos registrados es {productsQuantity}");
        }

        public async Task<IActionResult> Update(int id, Producto item)
        {
            var productId = await _context.Productos.FindAsync(id);
            if (productId == null) { return new NotFoundObjectResult("No se encontro el producto"); }

            productId.Id = item.Id;
            productId.Nombre = item.Nombre;
            productId.Precio = item.Precio;
            productId.Stock = item.Stock;
            productId.IdCategoria = item.IdCategoria;
            productId.IdProveedor = item.IdProveedor;

            await _context.SaveChangesAsync();

            return new ObjectResult("Se edito el producto");

        }
    }
}
