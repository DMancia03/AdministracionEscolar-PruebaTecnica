using System.ComponentModel.DataAnnotations.Schema;

namespace AdministracionEscolar.Models
{
    public class BaseBitacora
    {
        [Column("ESTADO", TypeName = "NVARCHAR(1)")]
        public string Estado { get; set; } = null!;

        [Column("USU_CREA", TypeName = "NVARCHAR(100)")]
        public string UsuCrea { get; set; } = null!;

        [Column("FEC_CREA", TypeName = "DATETIME")]
        public DateTime FecCrea { get; set; }

        [Column("USU_MOD", TypeName = "NVARCHAR(100)")]
        public string? UsuMod { get; set; }

        [Column("FEC_MOD", TypeName = "DATETIME")]
        public DateTime? FecMod { get; set; }

        [Column("USU_BLO", TypeName = "NVARCHAR(100)")]
        public string? UsuBlo { get; set; }

        [Column("FEC_BLO", TypeName = "DATETIME")]
        public DateTime? FecBlo { get; set; }
    }
}
