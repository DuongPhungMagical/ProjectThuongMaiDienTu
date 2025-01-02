using Microsoft.AspNetCore.Mvc;

namespace AppView.Controllers
{
	public class LoginController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
