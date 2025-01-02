using AppModel;
using AppModel.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly DataContext _context;
		public CategoryController(DataContext context)
		{
			_context = context;
		}
		[HttpGet]
		public async Task<ActionResult<CategoryModel>> GetCategory(string slug = "")
		{
			CategoryModel categoryModel = _context.Categories.Where(x => x.Slug == slug).FirstOrDefault();
			if (categoryModel == null)
			{
				return NotFound();
			}
			var productByCategory = _context.Products.Where(x => x.Id == categoryModel.Id);
			return Ok(await productByCategory.OrderByDescending(x => x.Id).ToListAsync());
		}
	}
}
