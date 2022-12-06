using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MCard40.Model.Entity;
using MCard40.Web.Data;
using MCard40.Infrastucture.Services.Interfaces;
using MCard40.Data.Context;

namespace MCard40.Web.Controllers
{
    public class CardPageController : Controller
    {
        private readonly ICardPageService _service;

        public CardPageController(ICardPageService service)
        {
            _service = service;
        }

        // GET: CardPage
        public async Task<IActionResult> Index()
        {
            List<CardPage> cardPages = _service.GetAll();

            if (cardPages == null)
            {
                return NotFound();
            }

            return View(cardPages);
        }

        // GET: CardPage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            CardPage cardPage = _service.GetCardPageDetails(id);

            if (cardPage == null)
            {
                return NotFound();
            }

            return View(cardPage);
        }

        // GET: CardPage/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CardPage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Disease,DiseaseInfo,Treatment,Assessment,PatientId,DoctorId")] CardPage cardPage)
        {
            _service.Add(cardPage);
            return RedirectToAction(nameof(Index));
        }

        // GET: CardPage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var cardPage = _service.GetById(id);
            if (cardPage == null)
            {
                return NotFound();
            }
            return View(cardPage);
        }

        // POST: CardPage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Disease,DiseaseInfo,Treatment,Assessment,PatientId,DoctorId")] CardPage cardPage)
        {
            if (id != cardPage.Id)
            {
                return NotFound();
            }
            cardPage = _service.Update(id, cardPage);
            if (cardPage == null)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: CardPage/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var cardPage = _service.GetById(id);
            
            if (cardPage == null)
            {
                return NotFound();
            }

            return View(cardPage);
        }

        // POST: CardPage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cardPage = _service.Delete(id);

            if (cardPage == null)
            {
                return Problem("Entity set 'MCard40DbContext.CardPage'  is null.");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
