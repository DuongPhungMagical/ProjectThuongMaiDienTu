using AppModel;
using AppModel.Repository;
using AppModel.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CartController : ControllerBase
	{
		private readonly DataContext _context;
		public CartController(DataContext context)
		{
			_context = context;
		}
		[HttpGet("load")]
		public async Task<IActionResult> HienThi()
		{
			List<CartItemModel> cartItems = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();
			CartItemViewModel cartVM = new CartItemViewModel()
			{
				CartItems = cartItems,
				GrandTotal = cartItems.Sum(x => x.Quantity * x.Price)
			};
			return Ok(cartVM);
		}

		[HttpPost("add")]
		public async Task<IActionResult> AddToCart(int id)
		{
			var product = await _context.Products.FindAsync(id);
			List<CartItemModel> carts = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();
			var cartItem = carts.FirstOrDefault(x => x.ProductId == id);
			if (cartItem == null)
			{
				carts.Add(new CartItemModel(product));
			}
			else
			{
				cartItem.Quantity++;
			}
			HttpContext.Session.SetJson("Cart", carts);
			return Ok(new
			{
				Success = true,
				Message = "Sản phẩm đã được thêm vào giỏ hàng.",
			});
		}
		[HttpPost("decrease")]
		public async Task<IActionResult> Decrease(int id)
		{
			List<CartItemModel> carts = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();
			var cartItem = carts.FirstOrDefault(x => x.ProductId == id);
			if (cartItem.Quantity > 1)
			{
				--cartItem.Quantity;
			}
			else
			{
				carts.RemoveAll(x => x.ProductId == id);
			}
			if (carts.Count == 0)
			{
				HttpContext.Session.Remove("Cart");
			}
			else
			{
				HttpContext.Session.SetJson("Cart", carts);
			}
			return RedirectToAction("Index");
		}
		[HttpDelete("remove")]
		public async Task<IActionResult> Remove(int id)
		{
			List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart");
			cart.RemoveAll(x => x.ProductId == id);
			if(cart.Count == 0)
			{
				HttpContext.Session.Remove("Cart");
			}
			else
			{
				HttpContext.Session.SetJson("Cart", cart);
			}
			return Ok();
		}
	}
}
