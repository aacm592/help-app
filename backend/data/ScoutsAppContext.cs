using backend.data.models;
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
      new Distrito { Id = 1, Nombre = "Cochabamba" },
      new Distrito { Id = 2, Nombre = "Pando" }
    );

    // Siembra de Ramas
    modelBuilder.Entity<Rama>().HasData(
      new Rama { Id = 1, Nombre = "Lobatos", EdadMinima = 7, EdadMaxima = 11 },
      new Rama { Id = 2, Nombre = "Exploradores", EdadMinima = 11, EdadMaxima = 15 },
      new Rama { Id = 3, Nombre = "Pioneros", EdadMinima = 15, EdadMaxima = 18 },
      new Rama { Id = 4, Nombre = "Rovers", EdadMinima = 18, EdadMaxima = 21 }
    );

    // Siembra de Grupos Scout
    modelBuilder.Entity<GrupoScout>().HasData(
      new GrupoScout { Id = 1, Nombre = "Tunari", DistritoId = 1 },
      new GrupoScout { Id = 2, Nombre = "Cobija", DistritoId = 2 }
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
    
    modelBuilder.Entity<User>()
      .HasOne(u => u.Profile)
      .WithOne(p => p.User)
      .HasForeignKey<UserProfile>(p => p.Id);
  }
}
