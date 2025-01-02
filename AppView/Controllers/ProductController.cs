using AppModel;
using AppModel.Repository;
using Microsoft.AspNetCore.Mvc;
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
			string requestUrl = $@"https://localhost:7142/api/Product";
			var responseBody = await _client.GetStringAsync(requestUrl);
			var data = JsonConvert.DeserializeObject<List<ProductModel>>(responseBody);
			return View(data);
		}
		public IActionResult Details()
		{
			return View();
		}
	}
}
