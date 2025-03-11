using AdministracionEscolar.Data;
using AdministracionEscolar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdministracionEscolar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstudianteController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<EstudianteController> _logger;

        private AdminEscolarDbContext _db;

        public EstudianteController(ILogger<EstudianteController> logger, AdminEscolarDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<Estudiante> Get()
        {
            return _db.Estudiantes.ToList();
        }
    }
}
