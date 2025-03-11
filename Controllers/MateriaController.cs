using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionEscolar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MateriaController : Controller
    {
        // GET: MateriaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MateriaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MateriaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MateriaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MateriaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MateriaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MateriaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MateriaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
