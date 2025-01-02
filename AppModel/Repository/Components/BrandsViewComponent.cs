using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModel.Repository.Components
{
	public class BrandsViewComponent : ViewComponent
	{
		private readonly DataContext _context;
		public BrandsViewComponent(DataContext context)
		{
			_context = context;
		}
		public async Task<IViewComponentResult> InvokeAsync() => View(await _context.Brands.ToListAsync());
	}
}
