using MCard40.Infrastucture.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MCard40.Web.Controllers
{
	public class WeekController : Controller
	{
		public readonly IWeekService _service;

		public WeekController(IWeekService service)
		{
			_service = service;
		}

		public IActionResult Index(int id)
		{
			return View(_service.GetAll(id));
		}
		
	}
}
