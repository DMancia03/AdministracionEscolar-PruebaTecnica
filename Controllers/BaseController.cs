using AdministracionEscolar.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionEscolar.Controllers
{
    public class BaseController : Controller
    {
        protected AdminEscolarDbContext _db;
        protected static string _usuario = "admin";
    }
}
