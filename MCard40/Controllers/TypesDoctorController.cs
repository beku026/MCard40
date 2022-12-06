using Microsoft.AspNetCore.Mvc;

namespace MCard40.Web.Controllers
{
    public class TypesDoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
		public IActionResult Price()
		{
			return View();
		}
    }
}
