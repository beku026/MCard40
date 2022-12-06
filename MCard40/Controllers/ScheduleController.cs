using MCard40.Infrastucture.Services.Interfaces;
using MCard40.Infrastucture.ViewModels.CardPage;
using MCard40.Model.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace MCard40.Web.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly IWeekService _serviceWeek;
        private readonly IWorkDayService _serviceWorkDay;
        private readonly IDoctorService _serviceDoc;

        public ScheduleController(IWeekService serviceWeek,
            IWorkDayService serviceWorkDay, 
            IDoctorService serviceDoc)
        {
            _serviceWeek = serviceWeek;
            _serviceWorkDay = serviceWorkDay;
            _serviceDoc = serviceDoc;
        }
        // GET: ScheduleController
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            ViewBag.CurrentFilter = searchString;

            var doctors = _serviceDoc.GetFiltered(sortOrder, searchString);

            if (doctors == null)
                return NotFound();

            //List<Week> week = _serviceWeek.GetAll();
            //List<WorkDay> workDays= _serviceWorkDay.GetAll();
            //if (week == null)
            //{
            //    return NotFound();
            //}
            //if (workDays == null)
            //{
            //    return NotFound();
            //}

            //return View(week);
            return View(doctors.ToList()); 
        }

        // GET: ScheduleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ScheduleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ScheduleController/Create
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

        // GET: ScheduleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ScheduleController/Edit/5
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

        // GET: ScheduleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ScheduleController/Delete/5
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
