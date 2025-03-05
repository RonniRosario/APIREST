
using EjercicioAPIRest.DB;
using EjercicioAPIRest.JWT;
using EjercicioAPIRest.Models;
using EjercicioAPIRest.Services.AuthServices;
using EjercicioAPIRest.Services.CRUDService;
using EjercicioAPIRest.Services.CRUDServices;
using EjercicioAPIRest.Services.ProductQueries;
using EjercicioAPIRest.Services.UsuariosServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EjercicioAPIRest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<EjercicioAPIRestContext>(op =>
            {
                op.UseSqlServer(builder.Configuration.GetConnectionString("EjercicioAPI"));
            });
            builder.Services.AddScoped<ICrudServices<Usuario>, UsuariosServices>();
            builder.Services.AddScoped<ICrudServices<Categoria>, CategoriasServices>();
            builder.Services.AddScoped<ICrudServices<Producto>, ProductosServices>();
            builder.Services.AddScoped<IProductsInfo<Producto>, ProductosServices>();
            builder.Services.AddScoped<ICrudServices<Proveedor>, ProveedorServices>();



            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<RefreshTokenServices>();
            builder.Services.AddSingleton<Utilities>();
            builder.Services.AddAuthentication(config =>
            {
                config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(config =>
            {
                config.RequireHttpsMetadata = false;
                config.SaveToken = true;
                config.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime =true,
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:key"]!))
                };
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
