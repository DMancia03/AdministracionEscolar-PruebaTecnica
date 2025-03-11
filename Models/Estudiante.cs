using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdministracionEscolar.Models
{
    [Table("ESTUDIANTE")]
    public class Estudiante : BaseBitacora
    {
        [Key]
        [Column("CODIGO", TypeName = "NVARCHAR(8)")]
        public string Codigo { get; set; } = null!;

        [Column("NOMBRES", TypeName = "NVARCHAR(100)")]
        public string Nombres { get; set; } = null!;

        [Column("APELLIDOS", TypeName = "NVARCHAR(100)")]
        public string Apellidos { get; set; } = null!;

        [Column("FECHA_NACIMIENTO", TypeName = "DATETIME")]
        public DateTime FechaNacimiento { get; set; }

        [Column("EDAD")]
        public int Edad { get; set; }

        [Column("CORREO", TypeName = "NVARCHAR(100)")]
        public string Correo { get; set; } = null!;

        public ICollection<EstudianteMateria>? EstudianteMaterias { get; set; }
    }
}
