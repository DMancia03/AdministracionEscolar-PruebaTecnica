using System.ComponentModel.DataAnnotations.Schema;

namespace AdministracionEscolar.BussinessModels
{
    public class BMateria
    {
        public string Codigo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Instructor { get; set; } = null!;
        public string HoraInicio { get; set; } = null!;
        public string HoraFin { get; set; } = null!;
        public string Ubicacion { get; set; } = null!;
        public string? Estado { get; set; }
        public string? UsuCrea { get; set; }
        public DateTime? FecCrea { get; set; }
        public string? UsuMod { get; set; }
        public DateTime? FecMod { get; set; }
        public string? UsuBlo { get; set; }
        public DateTime? FecBlo { get; set; }
    }
}
