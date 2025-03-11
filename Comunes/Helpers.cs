using AdministracionEscolar.BussinessModels;
using AdministracionEscolar.Models;

namespace AdministracionEscolar.Comunes
{
    public class Helpers
    {
        public static Estudiante BEstudianteToEstudiante(BEstudiante entity, string username, bool esEdicion = false)
        {
            if (esEdicion)
            {
                return new Estudiante
                {
                    //Codigo = entity.Codigo,
                    Nombres = entity.Nombres,
                    Apellidos = entity.Apellidos,
                    FechaNacimiento = entity.FechaNacimiento,
                    Edad = entity.Edad,
                    Correo = entity.Correo,
                    Estado = entity.Estado,
                    UsuCrea = entity.UsuCrea,
                    FecCrea = entity.FecCrea.Value,
                    UsuMod = username, //
                    FecMod = DateTime.Now, //
                    UsuBlo = entity.UsuBlo,
                    FecBlo = entity.FecBlo
                };
            }
            else
            {
                return new Estudiante
                {
                    Codigo = entity.Codigo,
                    Nombres = entity.Nombres,
                    Apellidos = entity.Apellidos,
                    FechaNacimiento = entity.FechaNacimiento,
                    Edad = entity.Edad,
                    Correo = entity.Correo,
                    Estado = Strings.ESTADO_ACTIVO,
                    UsuCrea = username,
                    FecCrea = DateTime.Now,
                    UsuMod = entity.UsuMod,
                    FecMod = entity.FecMod,
                    UsuBlo = entity.UsuBlo,
                    FecBlo = entity.FecBlo
                };
            }
        }

        public static Materia BMateriaToMateria(BMateria materia, string username, bool esEdicion = false)
        {
            if (esEdicion)
            {
                return new Materia
                {
                    //Codigo = materia.Codigo,
                    Nombre = materia.Nombre,
                    Instructor = materia.Instructor,
                    HoraInicio = materia.HoraInicio,
                    HoraFin = materia.HoraFin,
                    Ubicacion = materia.Ubicacion,
                    Estado = materia.Estado,
                    UsuCrea = materia.UsuCrea,
                    FecCrea = materia.FecCrea.Value,
                    UsuMod = username, //
                    FecMod = DateTime.Now, //
                    UsuBlo = materia.UsuBlo,
                    FecBlo = materia.FecBlo
                };
            }
            else
            {
                return new Materia
                {
                    Codigo = materia.Codigo,
                    Nombre = materia.Nombre,
                    Instructor = materia.Instructor,
                    HoraInicio = materia.HoraInicio,
                    HoraFin = materia.HoraFin,
                    Ubicacion = materia.Ubicacion,
                    Estado = Strings.ESTADO_ACTIVO, //
                    UsuCrea = username, //
                    FecCrea = DateTime.Now, //
                    UsuMod = materia.UsuMod,
                    FecMod = materia.FecMod, 
                    UsuBlo = materia.UsuBlo,
                    FecBlo = materia.FecBlo
                };
            }
        }
    }
}
