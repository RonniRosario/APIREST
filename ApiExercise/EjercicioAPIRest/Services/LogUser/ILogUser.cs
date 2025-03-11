using Microsoft.AspNetCore.Mvc;

namespace EjercicioAPIRest.Services.LogUser
{
    public interface ILogUser<T> where T : class
    {
        Task<ActionResult<T>> ReadLog();
    }
}
