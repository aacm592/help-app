using backend.data.models;
using backend.data.models.especialidades;
using backend.data.seeders;
using Microsoft.EntityFrameworkCore;

namespace backend.data;

public class ScoutsAppContext: DbContext
{
  public ScoutsAppContext(DbContextOptions<ScoutsAppContext> options) : base(options)
  {
  }

  public DbSet<User> Users { get; set; }
  public DbSet<Tipo> Tipos { get; set; }
  public DbSet<Permiso> Permisos { get; set; }
  public DbSet<Unidad> Unidades { get; set; }
  public DbSet<GrupoScout> GruposScout { get; set; }
  public DbSet<Rama> Ramas { get; set; }
  public DbSet<Distrito> Distritos { get; set; }
  public DbSet<ObjetivoEducativo> ObjetivosEducativos { get; set; }
  public DbSet<AreaCrecimiento> AreasCrecimiento { get; set; }
  public DbSet<EtapaProgresion> EtapasProgresion { get; set; }
  public DbSet<ObjetivoUsuario> ObjetivosUsuario { get; set; }
  public DbSet<UserProfile> UserProfiles { get; set; }
  public DbSet<Especialidad> Especialidades { get; set; }
  public DbSet<RequisitoEsp> RequisitosEsp { get; set; }
  public DbSet<RequisitoEspUser> RequisitoEspUsers { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    // Siembra de datos para la tabla Tipos
    modelBuilder.Entity<Tipo>().HasData(
      new Tipo { Id = 1, Nombre = "Scout" },
      new Tipo { Id = 2, Nombre = "Dirigente" }
    );
    
    // Siembra de Distritos
    modelBuilder.Entity<Distrito>().HasData(
      new Distrito { Id = 1, Nombre = "Beni" },
      new Distrito { Id = 2, Nombre = "Chuquisaca" },
      new Distrito { Id = 3, Nombre = "Cochabamba" },
      new Distrito { Id = 4, Nombre = "La Paz" },
      new Distrito { Id = 5, Nombre = "Oruro" },
      new Distrito { Id = 6, Nombre = "Potosi" },
      new Distrito { Id = 7, Nombre = "Santa Cruz" },
      new Distrito { Id = 8, Nombre = "Tarija" }
    );

    // Siembra de Ramas
    modelBuilder.Entity<Rama>().HasData(
      new Rama { Id = 1, Nombre = "Lobatos", EdadMinima = 7, EdadMaxima = 11 },
      new Rama { Id = 2, Nombre = "Exploradores", EdadMinima = 11, EdadMaxima = 15 },
      new Rama { Id = 3, Nombre = "Pioneros", EdadMinima = 15, EdadMaxima = 18 },
      new Rama { Id = 4, Nombre = "Rovers", EdadMinima = 18, EdadMaxima = 21 }
    );
    
    // Siembra de Etapas de progresión
    modelBuilder.Entity<EtapaProgresion>().HasData(
      new EtapaProgresion() { Id = 1, Nombre = "Pata tierna - Saltador", RamaId = 1},
      new EtapaProgresion() { Id = 2, Nombre = "Rastreador - Cazador", RamaId = 1},
      new EtapaProgresion() { Id = 3, Nombre = "Pista - Senda", RamaId = 2},
      new EtapaProgresion() { Id = 4, Nombre = "Rumbo - Travesía", RamaId = 2},
      new EtapaProgresion() { Id = 5, Nombre = "Busqueda - Encuentro - Desafío", RamaId = 3},
      new EtapaProgresion() { Id = 6, Nombre = "Caminante - Aspirante - Rover", RamaId = 4}
    );
    
    // Siembra de Áreas de Crecimiento
    modelBuilder.Entity<AreaCrecimiento>().HasData(
      new AreaCrecimiento { Id = 1, Nombre = "Corporalidad" },
      new AreaCrecimiento { Id = 2, Nombre = "Carácter" },
      new AreaCrecimiento { Id = 3, Nombre = "Afectividad" },
      new AreaCrecimiento { Id = 4, Nombre = "Sociabilidad" },
      new AreaCrecimiento { Id = 5, Nombre = "Espiritualidad" },
      new AreaCrecimiento { Id = 6, Nombre = "Creatividad" }
    );
    
    var objetivosDesdeCsv = ObjetivoEducativoCsvSeeder.GetData();
    if (objetivosDesdeCsv.Any())
      modelBuilder.Entity<ObjetivoEducativo>().HasData(objetivosDesdeCsv);
    
    var gruposDesdeCsv = GrupoScoutCsvSeeder.GetData();
    if (gruposDesdeCsv.Any())
      modelBuilder.Entity<GrupoScout>().HasData(gruposDesdeCsv);
    
    var especialidadesDesdeCsv = EspecialidadesCsvSeeder.GetData();
    if (especialidadesDesdeCsv.Any())
      modelBuilder.Entity<Especialidad>().HasData(especialidadesDesdeCsv);
    
    var requisitosEspecialidadesDesdeCsv = RequisitosEspecialidadesCsvSeeder.GetData();
    if (requisitosEspecialidadesDesdeCsv.Any())
      modelBuilder.Entity<RequisitoEsp>().HasData(requisitosEspecialidadesDesdeCsv);

    
    modelBuilder.Entity<Tipo>()
      .HasMany(t => t.Permisos)
      .WithMany(p => p.Tipos)
      .UsingEntity(j => j.ToTable("PermisosTipo"));

    modelBuilder.Entity<User>()
      .HasMany(u => u.Unidades)
      .WithMany(un => un.Usuarios)
      .UsingEntity(j => j.ToTable("UnidadUsuario"));
    
    modelBuilder.Entity<EtapaProgresion>()
      .HasOne(e => e.Rama)
      .WithMany(r => r.EtapasProgresion)
      .HasForeignKey(e => e.RamaId);
    
    modelBuilder.Entity<ObjetivoUsuario>(entity =>
    {
      entity.HasKey(ou => new { ou.UsuarioId, ou.ObjetivoEducativoId });
      entity.HasOne(ou => ou.User)
        .WithMany(u => u.ObjetivosUsuario)
        .HasForeignKey(ou => ou.UsuarioId);

      entity.HasOne(ou => ou.ObjetivoEducativo)
        .WithMany(o => o.UsuariosObjetivo)
        .HasForeignKey(ou => ou.ObjetivoEducativoId); 
      entity.Property(ou => ou.Status)
        .HasConversion<string>();
      
      entity.HasOne(ou => ou.DirigenteAprobo)
        .WithMany()
        .HasForeignKey(ou => ou.DirigenteAproboId)
        .OnDelete(DeleteBehavior.Restrict);
    });

    modelBuilder.Entity<RequisitoEspUser>(entity =>
    {
      entity.HasKey(e => new {e.RequisitoId, e.UsuarioId});
      
      entity.HasOne(e => e.Usuario)
        .WithMany(r => r.RequisitoEspUser)
        .HasForeignKey(e => e.UsuarioId);
      
      entity.HasOne(e => e.Requisito)
        .WithMany(r => r.RequisitosEspUser)
        .HasForeignKey(r => r.RequisitoId);

      entity.Property(e => e.Status)
        .HasConversion<string>();
      
      entity.HasOne(e => e.DirigenteAprobo)
        .WithMany()
        .HasForeignKey(e => e.DirigenteAproboId)
        .OnDelete(DeleteBehavior.Restrict);
    });
    
    modelBuilder.Entity<User>()
      .HasOne(u => u.Profile)
      .WithOne(p => p.User)
      .HasForeignKey<UserProfile>(p => p.Id);
  }
}
