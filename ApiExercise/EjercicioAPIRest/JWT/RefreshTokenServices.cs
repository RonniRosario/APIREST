using EjercicioAPIRest.DB;
using EjercicioAPIRest.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace EjercicioAPIRest.JWT
{
    public class RefreshTokenServices
    {
        private readonly EjercicioAPIRestContext _context;

        public RefreshTokenServices(EjercicioAPIRestContext context)
        {
            _context = context;
        }

        public string GenerateRefreshToken()
        {
            var randomBytes = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }
            return Convert.ToBase64String(randomBytes);
        }

        public async Task StoreRefreshTokenAsync(int userId, string refreshToken)
        {
            var token = new RefreshTokens
            {
                UserId = userId,
                Token = refreshToken,
                Expiration = DateTime.UtcNow.AddDays(7) // Expira en 7 días
            };

            _context.RefreshToken.Add(token);
            await _context.SaveChangesAsync();
        }

        public async Task<int?> ValidateRefreshTokenAsync(string refreshToken)
        {
            var refreshTokenRecord = await _context.RefreshToken
                .FirstOrDefaultAsync(rt => rt.Token == refreshToken);

            if (refreshTokenRecord == null)
            {
                return null; 
            }

            return refreshTokenRecord.UserId; 
        }

    }
}
