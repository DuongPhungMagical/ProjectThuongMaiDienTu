using AppModel;
using AppModel.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BrandController : ControllerBase
	{
		private readonly DataContext _context;
		public BrandController(DataContext context)
		{
			_context = context;
		}
		[HttpGet]
		public async Task<ActionResult> GetBrand(string slug = "")
		{
			BrandModel brandModel = _context.Brands.Where(x => x.Slug == slug).FirstOrDefault();
			if (brandModel == null)
			{
				return NotFound();
			}
			var productByBrand = _context.Products.Where(x => x.Id == brandModel.Id);
			return Ok(await productByBrand.OrderByDescending(x => x.Id).ToListAsync());
		}
	}
}
