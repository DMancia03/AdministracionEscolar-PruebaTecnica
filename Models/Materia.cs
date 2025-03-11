using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdministracionEscolar.Models
{
    [Table("MATERIA")]
    public class Materia : BaseBitacora
    {
        [Key]
        [Column("CODIGO", TypeName = "NVARCHAR(8)")]
        public string Codigo { get; set; } = null!;

        [Column("NOMBRE", TypeName = "NVARCHAR(100)")]
        public string Nombre { get; set; } = null!;

        [Column("INSTRUCTOR", TypeName = "NVARCHAR(100)")]
        public string Instructor { get; set; } = null!;

        [Column("HORA_INICIO", TypeName = "TIME")]
        public TimeOnly HoraInicio { get; set; }

        [Column("HORA_Fin", TypeName = "TIME")]
        public TimeOnly HoraFin { get; set; }

        [Column("UBICACION", TypeName = "NVARCHAR(100)")]
        public string Ubicacion { get; set; } = null!;

        public ICollection<EstudianteMateria>? EstudianteMaterias { get; set; }
    }
}
