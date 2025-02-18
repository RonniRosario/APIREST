using EjercicioAPIRest.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EjercicioAPIRest.AppValidations
{
    public class Validations
    {
        private readonly DB.EjercicioAPIRestContext _context;

        public Validations(DB.EjercicioAPIRestContext context)
        {
            _context = context;
        }
        public async Task<bool> DuplicateEmails(Usuario user)
        {
            return await _context.Usuarios.AnyAsync(x => x.Email == user.Email);

        }
    }
}
