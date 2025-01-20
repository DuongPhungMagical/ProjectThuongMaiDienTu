using AppModel;
using AppModel.Repository;
using AppModel.ViewModels;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AppView.Controllers
{
	public class CartController : Controller
	{
		private readonly HttpClient _client;

		public CartController(HttpClient client)
		{
			_client = client;
		}
		public async Task<IActionResult> Index()
		{
			string requestUrl = $@"https://localhost:7142/api/Cart/load";
			var responseBody = await _client.GetStringAsync(requestUrl);
			var data = JsonConvert.DeserializeObject<CartItemViewModel>(responseBody);
			return View(data);
		}
		public IActionResult Checkout()
		{
			return View("~/Views/Checkout/Index.cshtml");
		}
		public async Task<ActionResult> AddToCart(int id)
		{
			string requestUrl = $@"https://localhost:7142/api/Cart/add?id={id}";
			var responseBody = await _client.PostAsJsonAsync(requestUrl, new {id});
			TempData["success"] = "Add item to cart successfully";

			return Redirect(Request.Headers["Referer"].ToString());
		}
		public async Task<ActionResult> Decrease(int id)
		{
			string requestUrl = $@"https://localhost:7142/api/Cart/decrease?id={id}";
			var responseBody = await _client.PostAsJsonAsync(requestUrl, new { id });
			return Redirect(Request.Headers["Referer"].ToString());

		}
		public async Task<ActionResult> Remove(int id)
		{
			string requestUrl = $@"https://localhost:7142/api/Cart/remove?id={id}";
			var responseBody = await _client.DeleteAsync(requestUrl);
			return Redirect(Request.Headers["Referer"].ToString());
		}
	}
	





	

	//add

	//public async Task<ActionResult> Subtract(int id)
	//{
	//	List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart");
	//	CartItemModel cartItem = cart.Where(x => x.ProductId == id).FirstOrDefault();
	//	if(cartItem.Quantity > 1)
	//	{
	//		--cartItem.Quantity;
	//	}
	//	else
	//	{
	//		cart.RemoveAll(x => x.ProductId == id);
	//	}
	//	if (cart.Count == 0)
	//	{
	//		HttpContext.Session.Remove("Cart");
	//	}
	//	else 
	//	{ 
	//		HttpContext.Session.SetJson("Cart",cart);
	//	}
	//	return RedirectToAction("Index");
	//}
}

