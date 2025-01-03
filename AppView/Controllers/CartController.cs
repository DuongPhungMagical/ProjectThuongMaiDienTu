using AppModel;
using AppModel.Repository;
using AppModel.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AppView.Controllers
{
	public class CartController : Controller
	{
		private readonly DataContext _context;

		public CartController(DataContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			List<CartItemModel> cartItems = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();
			CartItemViewModel cartVm = new CartItemViewModel
			{
				CartItems = cartItems,
				GrandTotal = cartItems.Sum(x => x.Price * x.Quantity)
			};
			return View(cartVm);
		}
		public IActionResult Checkout()
		{
			return View("~/Views/Checkout/Index.cshtml");
		}
		//add
		public async Task<ActionResult> Add(int id)
		{
			ProductModel product = await _context.Products.FindAsync(id);
			List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();
			CartItemModel cartItems = cart.Where(x => x.ProductId == id).FirstOrDefault();
			if(cartItems == null)
			{
				cart.Add(new CartItemModel(product));
			}
			else
			{
				cartItems.Quantity += 1;
			}
			HttpContext.Session.SetJson("Cart", cart);
			return RedirectToAction("Index", "Home");
		}
		public async Task<ActionResult> Subtract(int id)
		{
			List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart");
			CartItemModel cartItem = cart.Where(x => x.ProductId == id).FirstOrDefault();
			if(cartItem.Quantity > 1)
			{
				--cartItem.Quantity;
			}
			else
			{
				cart.RemoveAll(x => x.ProductId == id);
			}
			if (cart.Count == 0)
			{
				HttpContext.Session.Remove("Cart");
			}
			else 
			{ 
				HttpContext.Session.SetJson("Cart",cart);
			}
			return RedirectToAction("Index");
		}
	}
}
