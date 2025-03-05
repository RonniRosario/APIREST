using EjercicioAPIRest.Models;
using Microsoft.AspNetCore.Mvc;

namespace EjercicioAPIRest.Services.ProductQueries
{
    public interface IProductsInfo<T> where T : class
    {
        Task<ActionResult<T>> ProductStats();
        Task<ActionResult<T>> CategoryProducts();
        Task<ActionResult<T>> ProviderProducts();
        Task<ActionResult<T>> ProductsQuantity();


    }
}
