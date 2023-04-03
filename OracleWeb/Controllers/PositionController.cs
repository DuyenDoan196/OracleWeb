using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OracleWeb.Interfaces;
using OracleWeb.Models;
using OracleWeb.Request;

namespace OracleWeb.Controllers
{
    public class PositionController : Controller
    {
        //interface
        private readonly IPositionServices _positionServices;
        public PositionController(IPositionServices positionServices)
        {
            _positionServices = positionServices;

        }
        // GET: PositionController
        public async Task<ActionResult> Index()
        {
            var positions = await _positionServices.GetAllPositionAsync();
            return View(positions);
        }

        // GET: PositionController/Details/5
        public async Task<ActionResult> DetailsAsync(int id)
        {
            var position = await _positionServices.GetPositionAsync(id);
            return View(position);
        }

        // GET: PositionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PositionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Positon collection)
        {
            try
            {
                var positionRequest = new PositionRequest
                {
                    Name = collection.Name,
                    Salary = collection.Salary
                };
                await _positionServices.CreatePositionAsync(positionRequest);
                return View("Index");
            }

            catch(Exception ex)
            {
                //viewbag controller-> view
                ViewBag.Exception = ex;
                return View();
            }
        }

        // GET: PositionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PositionController/Edit/5
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

        // GET: PositionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PositionController/Delete/5
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
