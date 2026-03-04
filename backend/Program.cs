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

var connectionString =
    config.GetConnectionString("DefaultConnection")
    ?? config["ConnectionStrings__DefaultConnection"];

if (string.IsNullOrWhiteSpace(connectionString))
{
  throw new InvalidOperationException(
      "No se encontró la cadena de conexión 'DefaultConnection'. " +
      "Configúrala en appsettings.json o en la variable de entorno ConnectionStrings__DefaultConnection."
  );
}

var frontendOrigin = config["FrontendOrigin"];

builder.Services.AddDbContext<ScoutsAppContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITipoRepository, TipoRepository>();
builder.Services.AddScoped<IUnidadRepository, UnidadRepository>();
builder.Services.AddScoped<IRamaRepository, RamaRepository>();
builder.Services.AddScoped<IGrupoScoutRepository, GrupoScoutRepository>();
builder.Services.AddScoped<IDistritoRepository, DistritoRepository>();
builder.Services.AddScoped<IEtapaProgresionRepository, EtapaProgresionRepository>();
builder.Services.AddScoped<IObjetivoEducativoRepository, ObjetivoEducativoRepository>();
builder.Services.AddScoped<IObjetivoUsuarioRepository, ObjetivoUsuarioRepository>();
builder.Services.AddScoped<IRequisitoEspRepository, RequisitoEspRepository>();
builder.Services.AddScoped<IEspecialidadRepository, EspecialidadRepository>();
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IRegistroRepository, RegistroRepository>();
builder.Services.AddScoped<IGestionRepository, GestionRepository>();
builder.Services.AddScoped<IPermisoRepository, PermisoRepository>();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUnidadService, UnidadService>();
builder.Services.AddScoped<IRamaService, RamaService>();
builder.Services.AddScoped<IGrupoScoutService, GrupoScoutService>();
builder.Services.AddScoped<IDistritoService, DistritoService>();
builder.Services.AddScoped<IEtapaProgresionService, EtapaProgresionService>();
builder.Services.AddScoped<IObjetivoEducativoService, ObjetivoEducativoService>();
builder.Services.AddScoped<IObjetivoUsuarioService, ObjetivoUsuarioService>();
builder.Services.AddScoped<IEspecialidadServer, EspecialidadServer>();
builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<IRegistroService, RegistroService>();
builder.Services.AddScoped<IGestionService, GestionService>();
builder.Services.AddScoped<IPermisosService, PermisosService>();

builder.Services.AddAutoMapper(typeof(Program));

var myAllowSpecificOrigins = "DefaultCors";
builder.Services.AddCors(options =>
{
  options.AddPolicy(name: myAllowSpecificOrigins,
    policy =>
    {
      policy.SetIsOriginAllowed(origin =>
        {
          if (origin is null) return false;
          return origin.Equals("https://app-asb.vercel.app") ||
                 origin.Equals("https://www.scoutsis.scoutsdebolivia.org") ||
                 origin.Equals("http://localhost:5173");
        })
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
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
      ValidIssuer = config["Jwt:Issuer"] ?? config["Jwt__Issuer"],
      ValidAudience = config["Jwt:Audience"] ?? config["Jwt__Audience"],
      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            config["Jwt:Key"] ?? config["Jwt__Key"]
                ?? throw new InvalidOperationException("Jwt:Key o Jwt__Key no configurado")
            ))
    };
  });

builder.Services.AddAuthorization();

builder.Services.AddControllers()
  .AddJsonOptions(options =>
  {
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
  });

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

using (var scope = app.Services.CreateScope())
{
  var services = scope.ServiceProvider;
  var db = services.GetRequiredService<ScoutsAppContext>();
  
  db.Database.Migrate();

  if (!db.Especialidades.Any())
  {
    var especialidades = backend.data.seeders.EspecialidadesCsvSeeder.GetData();
    db.Especialidades.AddRange(especialidades);
    db.SaveChanges();
  }

  if (!db.RequisitosEsp.Any())
  {
    var requisitos = backend.data.seeders.RequisitosEspecialidadesCsvSeeder.GetData();
    db.RequisitosEsp.AddRange(requisitos);
    db.SaveChanges();
  }
  
  if (!db.ObjetivosEducativos.Any())
  {
    var requisitos = backend.data.seeders.ObjetivoEducativoCsvSeeder.GetData();
    db.ObjetivosEducativos.AddRange(requisitos);
    db.SaveChanges();
  }
  
  if (!db.GruposScout.Any())
  {
    var requisitos = backend.data.seeders.GrupoScoutCsvSeeder.GetData();
    db.GruposScout.AddRange(requisitos);
    db.SaveChanges();
  }
}


app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(myAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
