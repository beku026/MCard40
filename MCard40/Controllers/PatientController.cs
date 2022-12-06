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

namespace MCard40.Web.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _service;

        public PatientController(IPatientService service)
        {
            _service= service;
        }

        // GET: Patient
        public IActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            ViewBag.CurrentFilter = searchString;

            var patients = _service.GetFiltered(sortOrder, searchString);

            if (patients == null)
                return NotFound();

            return View(patients.ToList());
        }

        // GET: Patient/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var doctor = _service.GetPatientDetails(id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // GET: Patient/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Patient/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,Age,Sex,ITN,Address,BloodGroup,Disability")] Patient patient)
        {
            _service.Add(patient);
            return RedirectToAction(nameof(Index));

        }

        // GET: Patient/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var patient = _service.GetById(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Age,Sex,ITN,Address,BloodGroup,Disability")] Patient patient)
        {
            if (id != patient.Id)
            {
                return NotFound();
            }
            patient = _service.Update(id, patient);
            if (patient == null)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Patient/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var patient = _service.GetById(id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // POST: Patient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patient = _service.Delete(id);
            if (patient == null)
            {
                return Problem("Entity set 'MCard40DbContext.Patient'  is null.");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
