using Microsoft.EntityFrameworkCore;
using backend.data;
using backend.repositories;
using backend.repositories.interfaces;
using backend.services;
using backend.services.interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

var connectionString = config.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ScoutsAppContext>(options =>
  options.UseNpgsql(connectionString));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITipoRepository, TipoRepository>();
builder.Services.AddScoped<IUnidadRepository, UnidadRepository>();
builder.Services.AddScoped<IRamaRepository, RamaRepository>();
builder.Services.AddScoped<IGrupoScoutRepository, GrupoScoutRepository>();
builder.Services.AddScoped<IDistritoRepository, DistritoRepository>();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUnidadService, UnidadService>();
builder.Services.AddScoped<IRamaService, RamaService>();
builder.Services.AddScoped<IGrupoScoutService, GrupoScoutService>();
builder.Services.AddScoped<IDistritoService, DistritoService>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowLocalhost", 
    builder => builder.WithOrigins("http://localhost:5173", "http://localhost:5174", 
        "https://localhost:5173", "https://localhost:5174")
      .AllowAnyMethod()
      .AllowAnyHeader());
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
  .AddJwtBearer(options => 
  {
    options.TokenValidationParameters = new TokenValidationParameters
    {
      ValidateIssuer = true,
      ValidateAudience = true,
      ValidateLifetime = true,
      ValidateIssuerSigningKey = true,
      ValidIssuer = config["Jwt:Issuer"],
      ValidAudience = config["Jwt:Audience"],
      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!))
    }; 
  });

builder.Services.AddAuthorization();
builder.Services.AddControllers()
  .AddJsonOptions(options =>
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())
    );

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
  options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
  {
    In = ParameterLocation.Header,
    Description = "Por favor ingresa el token JWT",
    Name = "Authorization",
    Type = SecuritySchemeType.Http,
    BearerFormat = "JWT",
    Scheme = "bearer"
  });

  options.AddSecurityRequirement(new OpenApiSecurityRequirement
  {
    {
      new OpenApiSecurityScheme
      {
        Reference = new OpenApiReference
        {
          Type = ReferenceType.SecurityScheme,
          Id = "Bearer"
        }
      },
      Array.Empty<string>()
    }
  });
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger(); 
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowLocalhost");

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
