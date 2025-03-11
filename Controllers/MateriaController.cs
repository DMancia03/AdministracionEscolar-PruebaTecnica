using AdministracionEscolar.BussinessModels;
using AdministracionEscolar.Comunes;
using AdministracionEscolar.Data;
using AdministracionEscolar.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AdministracionEscolar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MateriaController : BaseController
    {
        public MateriaController(AdminEscolarDbContext db)
        {
            _db = db;
        }

        [HttpGet(Name = "VerMaterias")]
        public IActionResult VerMaterias()
        {
            List<BMateria> materias = (from materia in _db.Materias
                                      select new BMateria
                                      {
                                          Codigo = materia.Codigo,
                                          Nombre = materia.Nombre,
                                          Instructor = materia.Instructor,
                                          HoraInicio = materia.HoraInicio,
                                          HoraFin = materia.HoraFin,
                                          Ubicacion = materia.Ubicacion,
                                          Estado = materia.Estado,
                                          UsuCrea = materia.UsuCrea,
                                          FecCrea = materia.FecCrea,
                                          UsuMod = materia.UsuMod,
                                          FecMod = materia.FecMod,
                                          UsuBlo = materia.UsuBlo,
                                          FecBlo = materia.FecBlo
                                      }).ToList();

            return Ok(materias);
        }

        [HttpGet("{codigoMateria}", Name = "VerMateria")]
        public IActionResult VerMateria(string codigoMateria)
        {
            if (codigoMateria.IsNullOrEmpty())
            {
                return NotFound();
            }

            BMateria materia = (from m in _db.Materias
                                where m.Codigo == codigoMateria
                                select new BMateria
                                {
                                    Codigo = m.Codigo,
                                    Nombre = m.Nombre,
                                    Instructor = m.Instructor,
                                    HoraInicio = m.HoraInicio,
                                    HoraFin = m.HoraFin,
                                    Ubicacion = m.Ubicacion,
                                    Estado = m.Estado,
                                    UsuCrea = m.UsuCrea,
                                    FecCrea = m.FecCrea,
                                    UsuMod = m.UsuMod,
                                    FecMod = m.FecMod,
                                    UsuBlo = m.UsuBlo,
                                    FecBlo = m.FecBlo
                                }).FirstOrDefault();

            if (materia == null)
            {
                return NotFound();
            }

            return Ok(materia);
        }

        [HttpGet("estudiante/{codigoEstudiante}", Name = "VerMateriaPorEstudiante")]
        public IActionResult VerMateriaPorEstudiante(string codigoEstudiante)
        {
            if (codigoEstudiante.IsNullOrEmpty())
            {
                return NotFound();
            }

            if(!_db.Estudiantes.Any(e => e.Codigo == codigoEstudiante))
            {
                return NotFound();
            }

            List<BMateria> materias = (from materia in _db.Materias
                                      join em in _db.EstudiantesMaterias on materia.Codigo equals em.CodigoMateria
                                      join est in _db.Estudiantes on em.CodigoEstudiante equals est.Codigo
                                      where em.CodigoEstudiante == codigoEstudiante
                                      select new BMateria
                                      {
                                          Codigo = materia.Codigo,
                                          Nombre = materia.Nombre,
                                          Instructor = materia.Instructor,
                                          HoraInicio = materia.HoraInicio,
                                          HoraFin = materia.HoraFin,
                                          Ubicacion = materia.Ubicacion,
                                          Estado = materia.Estado,
                                          UsuCrea = materia.UsuCrea,
                                          FecCrea = materia.FecCrea,
                                          UsuMod = materia.UsuMod,
                                          FecMod = materia.FecMod,
                                          UsuBlo = materia.UsuBlo,
                                          FecBlo = materia.FecBlo
                                      }).ToList();

            if (materias == null)
            {
                return NotFound();
            }

            return Ok(materias);
        }

        [HttpPost(Name = "CrearMateria")]
        public IActionResult CrearMateria([FromBody] BMateria materia)
        {
            if (_db.Materias.Any(m => m.Codigo == materia.Codigo))
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ya existe una materia con el código enviado.");
            }

            Materia registro = Helpers.BMateriaToMateria(materia, _usuario);

            try
            {
                _db.Materias.Add(registro);
                _db.SaveChanges();

                return Ok(materia);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{codigoMateria}", Name = "ActualizarMateria")]
        public IActionResult ActualizarMateria(string codigoMateria, [FromBody] BMateria materia)
        {
            if (codigoMateria.IsNullOrEmpty())
            {
                return NotFound();
            }

            Materia registro = _db.Materias.Find(codigoMateria);

            if (registro == null)
            {
                return NotFound();
            }

            materia.Estado = registro.Estado;
            materia.FecCrea = registro.FecCrea;
            materia.UsuCrea = registro.UsuCrea;

            registro = Helpers.BMateriaToMateria(materia, _usuario, true);

            try
            {
                _db.Materias.Update(registro);
                _db.SaveChanges();

                return Ok(registro);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
