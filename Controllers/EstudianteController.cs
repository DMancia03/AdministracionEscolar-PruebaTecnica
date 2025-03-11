using AdministracionEscolar.BussinessModels;
using AdministracionEscolar.Comunes;
using AdministracionEscolar.Data;
using AdministracionEscolar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;

namespace AdministracionEscolar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstudianteController : BaseController
    {
        public EstudianteController(AdminEscolarDbContext db)
        {
            _db = db;
        }

        [HttpGet(Name = "VerEstudiantes")]
        public IActionResult VerEstudiantes()
        {
            List<BEstudiante> estudiantes = (from entity in _db.Estudiantes
                                             select new BEstudiante
                                             {
                                                 Codigo = entity.Codigo,
                                                 Nombres = entity.Nombres,
                                                 Apellidos = entity.Apellidos,
                                                 FechaNacimiento = entity.FechaNacimiento,
                                                 Edad = entity.Edad,
                                                 Correo = entity.Correo,
                                                 Estado = entity.Estado,
                                                 UsuCrea = entity.UsuCrea,
                                                 FecCrea = entity.FecCrea,
                                                 UsuMod = entity.UsuMod,
                                                 FecMod = entity.FecMod,
                                                 UsuBlo = entity.UsuBlo,
                                                 FecBlo = entity.FecBlo
                                             }).ToList();

            return Ok(estudiantes);
        }

        [HttpGet("{codigoEstudiante}", Name = "VerEstudiante")]
        public IActionResult VerEstudiante(string codigoEstudiante)
        {
            if (codigoEstudiante.IsNullOrEmpty())
            {
                return NotFound();
            }

            BEstudiante estudiante = (from entity in _db.Estudiantes
                                      where entity.Codigo == codigoEstudiante
                                      select new BEstudiante
                                      {
                                          Codigo = entity.Codigo,
                                          Nombres = entity.Nombres,
                                          Apellidos = entity.Apellidos,
                                          FechaNacimiento = entity.FechaNacimiento,
                                          Edad = entity.Edad,
                                          Correo = entity.Correo,
                                          Estado = entity.Estado,
                                          UsuCrea = entity.UsuCrea,
                                          FecCrea = entity.FecCrea,
                                          UsuMod = entity.UsuMod,
                                          FecMod = entity.FecMod,
                                          UsuBlo = entity.UsuBlo,
                                          FecBlo = entity.FecBlo
                                      }).FirstOrDefault();

            if (estudiante == null)
            {
                return NotFound();
            }

            return Ok(estudiante);
        }

        [HttpPost(Name = "CrearEstudiante")]
        public IActionResult CrearEstudiante([FromBody] BEstudiante estudiante)
        {
            if (_db.Estudiantes.Any(e => e.Codigo == estudiante.Codigo))
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ya existe un estudiante con el código enviado.");
            }

            Estudiante registro = Helpers.BEstudianteToEstudiante(estudiante, _usuario);

            try
            {
                _db.Estudiantes.Add(registro);
                _db.SaveChanges();

                return Ok(estudiante);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{codigoEstudiante}", Name = "ActualizarEstudiante")]
        public IActionResult ActualizarEstudiante(string codigoEstudiante, [FromBody] BEstudiante estudiante)
        {
            if (codigoEstudiante.IsNullOrEmpty())
            {
                return NotFound();
            }

            Estudiante registro = _db.Estudiantes.Find(codigoEstudiante);
            

            if (registro == null)
            {
                return NotFound();
            }

            registro.Nombres = estudiante.Nombres;
            registro.Apellidos = estudiante.Apellidos;
            registro.FechaNacimiento = estudiante.FechaNacimiento;
            registro.Edad = estudiante.Edad;
            registro.Codigo = estudiante.Correo;
            registro.UsuMod = _usuario;
            registro.FecMod = DateTime.Now;

            try
            {
                _db.Estudiantes.Update(registro);
                _db.SaveChanges();

                return Ok(estudiante);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
