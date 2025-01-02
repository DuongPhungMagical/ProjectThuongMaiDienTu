using AppModel;
using AppModel.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly DataContext _context;
		public ProductController(DataContext context)
		{
			_context = context;
		}
		[HttpGet]
		public async Task<ActionResult<IEnumerable<ProductModel>>> GetProduct()
		{
			var danhSach = await _context.Products.Include(b => b.Brand).Include(c => c.Category).ToListAsync();
			return Ok(danhSach);
		}
	}
}
