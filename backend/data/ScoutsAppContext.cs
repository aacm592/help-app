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

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    // Siembra de datos para la tabla Tipos
    modelBuilder.Entity<Tipo>().HasData(
      new Tipo { Id = 1, Nombre = "Scout" },
      new Tipo { Id = 2, Nombre = "Dirigente" }
    );
    
    modelBuilder.Entity<Tipo>()
      .HasMany(t => t.Permisos)
      .WithMany(p => p.Tipos)
      .UsingEntity(j => j.ToTable("PermisosTipo"));

    modelBuilder.Entity<User>()
      .HasMany(u => u.Unidades)
      .WithMany(un => un.Usuarios)
      .UsingEntity(j => j.ToTable("UnidadUsuario"));
        
    modelBuilder.Entity<User>()
      .HasMany(u => u.ObjetivosEducativos)
      .WithMany(o => o.Usuarios)
      .UsingEntity<Dictionary<string, object>>(
        "ObjetivoUsuario",
        j => j.HasOne<ObjetivoEducativo>().WithMany().HasForeignKey("ObjetivoId"),
        j => j.HasOne<User>().WithMany().HasForeignKey("UsuarioId"),
        j =>
        {
          j.Property<string>("Status").HasMaxLength(50);
          j.HasKey("UsuarioId", "ObjetivoId");
        });
  }
}