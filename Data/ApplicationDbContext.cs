using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using proyectoIngSoft.Models;
namespace proyectoIngSoft.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<EnfermedadFam> EnfermedadF { get; set; }
    public DbSet<Maternidad> DbSetMaternidad { get; set; }
    public DbSet<Paternidad> DbSetPaternidad { get; set; }
    public DbSet<Fallecimiento> DbSetFallecimiento { get; set; }
    public DbSet<Accidente> DbSetAccidente { get; set; }
    public DbSet<Enfermedad> DbSetEnfermedad { get; set; }
    public DbSet<User> DbSetUser { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<User>()
        .Property(u => u.FechaNacimiento)
        .HasColumnType("timestamp without time zone");
}
}


