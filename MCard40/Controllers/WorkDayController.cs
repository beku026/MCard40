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

namespace MCard40.Web.Controllers
{
    public class WorkDayController : Controller
    {
        private readonly MCard40DbContext _context;

        public WorkDayController(MCard40DbContext context)
        {
            _context = context;
        }

        // GET: WorkDay
        public async Task<IActionResult> Index()
        {
            var mCard40DbContext = _context.WorkDays.Include(w => w.Week);
            return View(await mCard40DbContext.ToListAsync());
        }

        // GET: WorkDay/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.WorkDays == null)
            {
                return NotFound();
            }

            var workDay = await _context.WorkDays
                .Include(w => w.Week)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workDay == null)
            {
                return NotFound();
            }

            return View(workDay);
        }

        // GET: WorkDay/Create
        public IActionResult Create()
        {
            ViewData["WeekId"] = new SelectList(_context.Set<Week>(), "Id", "Id");
            return View();
        }

        // POST: WorkDay/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartWork,FinalWork,Employment_type,WeekId")] WorkDay workDay)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workDay);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["WeekId"] = new SelectList(_context.Set<Week>(), "Id", "Id", workDay.WeekId);
            return View(workDay);
        }

        // GET: WorkDay/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WorkDays == null)
            {
                return NotFound();
            }

            var workDay = await _context.WorkDays.FindAsync(id);
            if (workDay == null)
            {
                return NotFound();
            }
            ViewData["WeekId"] = new SelectList(_context.Set<Week>(), "Id", "Id", workDay.WeekId);
            return View(workDay);
        }

        // POST: WorkDay/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StartWork,FinalWork,Employment_type,WeekId")] WorkDay workDay)
        {
            if (id != workDay.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workDay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkDayExists(workDay.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["WeekId"] = new SelectList(_context.Set<Week>(), "Id", "Id", workDay.WeekId);
            return View(workDay);
        }

        // GET: WorkDay/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.WorkDays == null)
            {
                return NotFound();
            }

            var workDay = await _context.WorkDays
                .Include(w => w.Week)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workDay == null)
            {
                return NotFound();
            }

            return View(workDay);
        }

        // POST: WorkDay/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.WorkDays == null)
            {
                return Problem("Entity set 'MCard40WebContext.WorkDay'  is null.");
            }
            var workDay = await _context.WorkDays.FindAsync(id);
            if (workDay != null)
            {
                _context.WorkDays.Remove(workDay);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkDayExists(int id)
        {
          return _context.WorkDays.Any(e => e.Id == id);
        }
    }
}
