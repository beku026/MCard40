using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MCard40.Model.Entity;
using MCard40.Web.Data;
using MCard40.Data.Context;
//using X.PagedList;

namespace MCard40.Web.Controllers
{
    public class SearchDoctorController : Controller
    {
        private readonly MCard40DbContext _context;

        public SearchDoctorController(MCard40DbContext context)
        {
            _context = context;
        }

        // GET: Doctors
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var doctors = from s in _context.Doctors
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                doctors = doctors.Where(s => s.FullName.Contains(searchString)
                                      );
            }
            switch (sortOrder)
            {
                case "name_desc":
                    doctors = doctors.OrderByDescending(s => s.FullName);
                    break;
                case "Date":
                    doctors = doctors.OrderBy(s => s.Age);
                    break;
                default:
                    doctors = doctors.OrderBy(s => s.FullName);
                    break;
            }
            return View(doctors.ToList());
            //return View(await _context.Doctors.ToListAsync());

            //int pageSize = 3;
            //int pageNumber = (page ?? 1);
            //return View(doctors.ToPagedList(pageNumber, pageSize));
        }

        // GET: Doctors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Doctors == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctors
                .FirstOrDefaultAsync(m => m.Id == id);
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
<<<<<<< HEAD:MCard40/Controllers/SearchDoctorController.cs

=======
        [HttpPost] //enum
        public IActionResult Index(Doctor model)
        {
            return Content(model.Sex.ToString());
        }
        // POST: Doctors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,Age,Sex,ITN,Address_home,Post,Experience,Address_job,Degree")] Doctor doctor)
        {
                _context.Add(doctor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            return View(doctor);
        }
>>>>>>> 7c5bee4ba5ee5b67536b79df91d5dc30dadbb269:MCard40/Controllers/DoctorsController.cs

        // GET: Doctors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Doctors == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctors.FindAsync(id);
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

            //if (ModelState.IsValid)
            //{
                try
                {
                    _context.Update(doctor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorExists(doctor.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            //}
            return View(doctor);
        }

        private bool DoctorExists(int id)
        {
          return _context.Doctors.Any(e => e.Id == id);
        }
    }
}
