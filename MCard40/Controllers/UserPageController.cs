using System.Security.Claims;
using MCard40.Data.Context;
using MCard40.Infrastucture.Services.Interfaces;
using MCard40.Infrastucture.StaticClasses;
using MCard40.Model.Entity;
using MCard40.Web.Areas.Identity.Data;
using MCard40.Web.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MCard40.Web.Controllers;
public class UserPageController : Controller
{

    private readonly MCard40DbContext _dbContext;
    private readonly MCard40WebContext _identityDbContext;
    private readonly UserManager<MCardUser> _userManager;
    private readonly IDoctorService _serviceDoc;
    private readonly IPatientService _servicePat;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public UserPageController(UserManager<MCardUser> userManager, MCard40DbContext dbContext, IHttpContextAccessor httpContextAccessor, MCard40WebContext identityDbContext, IDoctorService serviceDoc, IPatientService servicePat)
    {
        _userManager = userManager;
        _dbContext = dbContext;
        _httpContextAccessor = httpContextAccessor;
        _identityDbContext = identityDbContext;
        _serviceDoc = serviceDoc;
        _servicePat = servicePat;
    }

    public string? UserId => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

    // GET: UserPageController
    public async Task<IActionResult> Index()
    {
        //var user = await GetCurrentUserAsync();
        var user = await _userManager.FindByIdAsync(UserId);
        var roles = await _userManager.GetRolesAsync(user);
        var role = roles.First();
        if (role == WC.Doctor)
        {
            var doc = _dbContext.Doctors.Include(x => x.User).FirstOrDefault(x => x.User.Id == user.Id);
            if (doc != null)
            {
                return RedirectToAction(nameof(DoctorAnketa), doc);
            }
            return RedirectToAction(nameof(DoctorCreateAnketa), routeValues: new { userId = user.Id });
        }
        else if (role == WC.Patient)
        {
            var pat = _dbContext.Patients.Include(x => x.User).FirstOrDefault(x => x.User.Id == user.Id);
            if (pat != null)
            {
                return RedirectToAction(nameof(PatientAnketa), pat);
            }
            return RedirectToAction(nameof(PatientCreateAnketa), routeValues: new { userId = user.Id });
        }
        return NotFound();
    }

 
    public async Task<IActionResult> PatientAnketa(Patient? patient)
    {
        return View(patient);
    }

    [HttpGet]
    public IActionResult PatientCreateAnketa(string userId)
    {
        ViewBag.UserId = UserId;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> PatientCreateAnketa([Bind("Id,FullName,Age,Sex,ITN,Address,BloodGroup,Disability,UserId")] Patient patient)
    {
        _dbContext.Add(patient);
        await _dbContext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> DoctorAnketa(Doctor? doctor)
    {
        return View(doctor);
    }

    [HttpGet]
    public IActionResult DoctorCreateAnketa(string userId)
    {
        ViewBag.UserId = UserId;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DoctorCreateAnketa([Bind("Id,FullName,Age,Sex,ITN,Address_home,Post,Experience,Address_job,Degree, UserId")] Doctor doctor)
    {
        _dbContext.Add(doctor);
        await _dbContext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    

    public async Task<IActionResult>DoctorAnketaEdit(Doctor doc)
    {
        var user = await _userManager.FindByIdAsync(UserId);
        var doctor = _dbContext.Doctors.Include(x => x.User).FirstOrDefault(x => x.User.Id == user.Id);
        ViewBag.UserId = UserId;
        if (doctor == null)
        {
            return NotFound();
        }
        return View(doctor);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DoctorAnketaEdit([Bind("Id,FullName,Age,Sex,ITN,Address_home,Post,Experience,Address_job,Degree, UserId")] Doctor doctor, int id)
    {
        if (id != doctor.Id)
        {
            return NotFound();
        }
        doctor = _serviceDoc.Update(id, doctor);
        if (doctor == null)
        {
            return NotFound();
        }

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> PatientAnketaEdit(Patient pat)
    {
        var user = await _userManager.FindByIdAsync(UserId);
        var patient = await _dbContext.Patients.Include(x => x.User).FirstOrDefaultAsync(x => x.User.Id == user.Id);
        ViewBag.UserId = UserId;
        if (patient == null)
        {
            return NotFound();
        }
        return View(patient);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> PatientAnketaEdit([Bind("Id,FullName,Age,Sex,ITN,Address,BloodGroup,Disability,UserId")] Patient patient, int id)
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

}
