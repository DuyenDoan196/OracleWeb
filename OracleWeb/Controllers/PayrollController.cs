using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OracleWeb.Interfaces;
using OracleWeb.Models;

namespace OracleWeb.Controllers
{
    public class PayrollController : Controller
    {
        // GET: PayrollController
        private readonly IPayrollServices _service;
        public PayrollController(IPayrollServices service)
        {
            _service = service;
        }

        public async Task<ActionResult> IndexAsync()
        {
            var res = await _service.GetAllAsync();
            return View(res);
        }

        // GET: PayrollController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var res = await _service.GetAsync(id);
            return View(res);
        }

        // GET: PayrollController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PayrollController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PayRoll collection)
        {
            try
            {
                await _service.CreateAsync(collection);
                return RedirectToAction(nameof(IndexAsync));
            }
            catch(Exception ex)
            {
                ViewBag.Exception = ex;
                return View();
            }
        }

        // GET: PayrollController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PayrollController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, PayRoll collection)
        {
            try
            {
                await _service.UpdateAsync(collection);
                return RedirectToAction(nameof(IndexAsync));
            }
            catch(Exception ex)
            {
                ViewBag.Exception = ex;
                return View();
            }
        }

        // GET: PayrollController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PayrollController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(decimal id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return RedirectToAction(nameof(IndexAsync));
            }
            catch(Exception ex)
            {
                ViewBag.Exception = ex;
                return View();
            }
        }
    }
}
