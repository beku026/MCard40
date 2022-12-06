using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MCard40.Model.Entity;
using MCard40.Web.Data;
using MCard40.Data.Context;
using MCard40.Infrastucture.Services.Interfaces;
//using X.PagedList;

namespace MCard40.Web.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _service;

        public DoctorController(IDoctorService service)
        {
            _service = service;
        }
        
        // GET: Doctors
        public IActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            ViewBag.CurrentFilter = searchString;
            
            var doctors = _service.GetFiltered(sortOrder, searchString);

            if(doctors == null)
                return NotFound();

            return View(doctors.ToList());
        }

        // GET: Doctors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var doctor = _service.GetDoctorDetails(id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // GET: Doctors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DoctorsExample/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,Age,Sex,ITN,Address_home,Post,Experience,Address_job,Degree")] Doctor doctor)
        {
            _service.Add(doctor);
            return RedirectToAction(nameof(Index));

        }

        // GET: Doctors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var doctor = _service.GetById(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }

        // POST: Doctors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Age,Sex,ITN,Address_home,Post,Experience,Address_job,Degree")] Doctor doctor)
        {
            if (id != doctor.Id)
            {
                return NotFound();
            }
            doctor = _service.Update(id, doctor);
            if (doctor == null)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
        
    }
}
