using EjercicioAPIRest.Login;
using EjercicioAPIRest.Models;
using Microsoft.AspNetCore.Mvc;

namespace EjercicioAPIRest.Services.AuthServices
{
    public interface IAuthService
    {
        Task<ActionResult> CreateUser(Usuario user);
        Task<ActionResult> Login(LoginDTO login);
        Task<ActionResult> RefreshToken(string refreshToken);
    }
}
