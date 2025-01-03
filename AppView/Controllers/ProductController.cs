using AppModel;
using AppModel.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AppView.Controllers
{
	public class ProductController : Controller
	{
		private readonly DataContext _context;
		private readonly HttpClient _client;
		public ProductController(DataContext context, HttpClient client)
		{
			_context = context;
			_client = client;
		}
		public async Task<IActionResult> Index()
		{
			return View();
		}
		public async Task<IActionResult> Details(int id)
		{
			if (id == null)
			{
				return RedirectToAction("Index");
			}
			string resquestUrl = $@"https://localhost:7142/api/Product/{id}";
			var reponseBody = await _client.GetStringAsync(resquestUrl);
			var data = JsonConvert.DeserializeObject<ProductModel>(reponseBody);
			return View(data);
		}
	}
}
