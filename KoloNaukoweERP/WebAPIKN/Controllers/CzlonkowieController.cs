using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIKN.Controllers
{
    public class CzlonkowieController : Controller
    {
        // GET: CzlonkowieController2
        public ActionResult Index()
        {
            return View();
        }

        // GET: CzlonkowieController2/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CzlonkowieController2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CzlonkowieController2/Create
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

        // GET: CzlonkowieController2/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CzlonkowieController2/Edit/5
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

        // GET: CzlonkowieController2/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CzlonkowieController2/Delete/5
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
