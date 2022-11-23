using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Proyecto.Core.Interfaces;
using Proyecto.Infraestructura.Data;
using Proyecto.Infraestructura.Repositorios;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
  e =>
  {
      e.SwaggerDoc("v1", new OpenApiInfo { Title = "API REST-NET 6", Version = "v1", Description= "Creacion de API Rest, Prueba DoublevPartners",
          Contact = new OpenApiContact
          {
              Name = "Mauricio Medina Sierra",
              Email ="mauriciomedinasierra@hotmail.com"
          },
      });
  });

//services cors
builder.Services.AddCors(p => p.AddPolicy("CorsApp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));


builder.Services.AddDbContext<dbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("conexion")));

builder.Services.AddTransient<IPersona, RepositorioPersonaSQL>();
builder.Services.AddTransient<IUsuario, RepositorioUsuarioSQL>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                           .GetBytes(builder.Configuration.GetSection("JWT:key").Value)),
                       ValidateIssuer = false,
                       ValidateAudience = false,
                       ValidateLifetime = true
                       
                   };
               });

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsApp");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
