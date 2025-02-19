﻿using AppModel.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AppView.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductController : Controller
	{
		private readonly DataContext _context;

		public ProductController(DataContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			return View();
		}
	}
}
