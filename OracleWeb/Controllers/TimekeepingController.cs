using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OracleWeb.Controllers
{
    public class TimekeepingController : Controller
    {
        // GET: TimekeepingController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TimekeepingController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TimekeepingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TimekeepingController/Create
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

        // GET: TimekeepingController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TimekeepingController/Edit/5
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

        // GET: TimekeepingController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TimekeepingController/Delete/5
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
