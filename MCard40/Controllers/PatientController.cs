using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MCard40.Model.Entity;
using MCard40.Web.Data;
using MCard40.Data.Context;
using MCard40.Infrastucture.Services.Interfaces;
using MCard40.Infrastucture.ViewModels.CardPage;
using MCard40.Infrastucture.StaticClasses;
using MCard40.Model.Identity;
using Microsoft.AspNetCore.Identity;
using MCard40.Web.Areas.Identity.Data;
using System.Security.Claims;

namespace MCard40.Web.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _servicePat;
        private readonly ICardPageService _serviceCard;
        private readonly MCard40DbContext _dbContext;
        //private readonly MCard40WebContext _identityDbContext;
        private readonly UserManager<MCardUser> _userManager;
        private readonly IDoctorService _serviceDoc;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public PatientController(IPatientService servicePat, ICardPageService serviceCard, UserManager<MCardUser> userManager, IDoctorService serviceDoc, MCard40DbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _servicePat = servicePat;
            _serviceCard = serviceCard;
            _userManager = userManager;
            _serviceDoc = serviceDoc;
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
        }
        public string? UserId => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

        // GET: Patient
        public IActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            ViewBag.CurrentFilter = searchString;

            var patients = _servicePat.GetFiltered(sortOrder, searchString);

            if (patients == null)
                return NotFound();

            return View(patients.ToList());
        }

        // GET: Patient/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var patient = _servicePat.GetPatientDetails(id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // GET: Patient/Create
        public IActionResult Create()
        {
            return View();
        }


        // GET: Patient/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var patient = _servicePat.GetById(id);
            ViewBag.UserId = UserId;
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        // POST: Patient/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Age,Sex,ITN,Address,BloodGroup,Disability,UserId")] Patient patient)
        {
            if (id != patient.Id)
            {
                return NotFound();
            }
            patient = _servicePat.Update(id, patient);
            if (patient == null)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> PatientCard(int id)
        {

            List<CardPage> cardPages = _serviceCard.GetAll(id);
            if (cardPages == null)
            {
                return NotFound();
            }
            ViewBag.PatientId = id;
            return View(cardPages);
        }
        public IActionResult CardCreate(int id)
        {
            ViewBag.PatientId = id;
            return View();
        }

        // POST: CardPage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CardCreate([Bind("Disease,DiseaseInfo,Treatment,Assessment,PatientId")] CardPage cardPage)
        {
            var user = await _userManager.FindByIdAsync(UserId);
            var roles = await _userManager.GetRolesAsync(user);
            var role = roles.First();
            if (role == WC.Doctor)
            {
                var doc = _dbContext.Doctors.Include(x => x.User).FirstOrDefault(x => x.User.Id == user.Id);
                if (doc != null)
                {
                    cardPage.DoctorId = doc.Id;
                    cardPage.DateСreation = DateTime.Now;
                    _serviceCard.Add(cardPage);
                    return RedirectToAction(nameof(PatientCard), routeValues: new { id = cardPage.PatientId});
                }
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> CardEdit(int? id)
        {
            var cardPage = _serviceCard.GetById(id);
            //var user = await _userManager.FindByIdAsync(UserId);
            //var doc = _dbContext.Doctors.Include(x => x.User).FirstOrDefault(x => x.User.Id == user.Id);
           
            if (cardPage == null)
            {
                return NotFound();
            }
            //ViewBag.DocId = cardPage.DoctorId;
            //ViewBag.PatId = cardPage.PatientId;
            return View(cardPage);
        }

        // POST: CardPage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CardEdit(int id, [Bind("Id,Disease,DiseaseInfo,Treatment,Assessment, PatientId, DoctorId")] CardPage cardPage)
        {
            if (id != cardPage.Id)
            {
                return NotFound();
            }
            cardPage.DateСreation = DateTime.Now;
            cardPage = _serviceCard.Update(id, cardPage);
            if (cardPage == null)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
        // GET:  CardPage/Details/5
        public async Task<IActionResult> CardDetails(int? id)
        {
            var cardPage = _serviceCard.GetCardPageDetails(id);
            if (cardPage == null)
            {
                return NotFound();
            }

            return View(cardPage);
        }
    }
}
