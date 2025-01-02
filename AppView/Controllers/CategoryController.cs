using AppModel;
using AppModel.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AppView.Controllers
{
	public class CategoryController : Controller
	{
		private readonly HttpClient _client;

		public CategoryController(HttpClient client)
		{
			_client = client;
		}
		public async Task<IActionResult> Index(string slug)
		{
			string requestUrl = $@"https://localhost:7142/api/Category?slug={slug}";
			var responseBody = await _client.GetStringAsync(requestUrl);
			var data = JsonConvert.DeserializeObject<List<ProductModel>>(responseBody);
			return View(data);
		}

	}
}
