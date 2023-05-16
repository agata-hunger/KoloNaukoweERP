using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class CzlonkowieControllerBackup : Controller //Check what is ControllerBase - probably wrong
    {
        private readonly IUnitOfWork unitOfWork;
        //check for what is mapper

        public CzlonkowieControllerBackup(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }



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
