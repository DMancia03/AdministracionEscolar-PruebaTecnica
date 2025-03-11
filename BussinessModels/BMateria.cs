using System.ComponentModel.DataAnnotations.Schema;

namespace AdministracionEscolar.BussinessModels
{
    public class BMateria
    {
        public string Codigo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Instructor { get; set; } = null!;
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFin { get; set; }
        public string Ubicacion { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public string UsuCrea { get; set; } = null!;
        public DateTime FecCrea { get; set; }
        public string? UsuMod { get; set; }
        public DateTime? FecMod { get; set; }
        public string? UsuBlo { get; set; }
        public DateTime? FecBlo { get; set; }
    }
}
}
