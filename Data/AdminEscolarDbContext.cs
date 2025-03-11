using AdministracionEscolar.Models;
using Microsoft.EntityFrameworkCore;

namespace AdministracionEscolar.Data
{
    public class AdminEscolarDbContext : DbContext
    {
        public AdminEscolarDbContext(DbContextOptions<AdminEscolarDbContext> options) : base(options)
        {
            //
        }

        public DbSet<Estudiante> Estudiantes { get; set; } = null!;
        public DbSet<Materia> Materias { get; set; } = null!;
        public DbSet<EstudianteMateria> EstudiantesMaterias { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EstudianteMateria>()
                .HasOne(em => em.Estudiante)
                .WithMany(e => e.EstudianteMaterias)
                .HasForeignKey(em => em.CodigoEstudiante)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EstudianteMateria>()
                .HasOne(em => em.Materia)
                .WithMany(m => m.EstudianteMaterias)
                .HasForeignKey(em => em.CodigoMateria)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
