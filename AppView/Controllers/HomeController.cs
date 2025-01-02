using AppModel;
using AppView.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AppView.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly HttpClient _httpClient;
		public HomeController(ILogger<HomeController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

		public async Task<IActionResult> Index()
		{
			string requestUrl = @"https://localhost:7142/api/Product";

			// Lấy dữ liệu từ API
			var responseBody = await _httpClient.GetStringAsync(requestUrl);
			var data = JsonConvert.DeserializeObject<List<ProductModel>>(responseBody); 

			return View(data);  
		}

		public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
