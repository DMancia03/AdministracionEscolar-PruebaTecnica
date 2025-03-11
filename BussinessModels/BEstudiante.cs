using System.ComponentModel.DataAnnotations.Schema;

namespace AdministracionEscolar.BussinessModels
{
    public class BEstudiante
    {
        public string Codigo { get; set; } = null!;
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public string Correo { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public string UsuCrea { get; set; } = null!;
        public DateTime FecCrea { get; set; }
        public string? UsuMod { get; set; }
        public DateTime? FecMod { get; set; }
        public string? UsuBlo { get; set; }
        public DateTime? FecBlo { get; set; }
    }
}
