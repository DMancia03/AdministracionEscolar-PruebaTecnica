using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdministracionEscolar.Models
{
    [Table("ESTUDIANTE_MATERIA")]
    public class EstudianteMateria
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("CODIGO_ESTUDIANTE", TypeName = "NVARCHAR(8)")]
        public string CodigoEstudiante { get; set; } = null!;

        [Column("CODIGO_MATERIA", TypeName = "NVARCHAR(8)")]
        public string CodigoMateria { get; set; } = null!;
        
        public Estudiante? Estudiante { get; set; }
        public Materia? Materia { get; set; }
    }
}
