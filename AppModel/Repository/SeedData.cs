using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModel.Repository
{
	public class SeedData
	{
		public static void SeedingData(DataContext _context)
		{
			_context.Database.Migrate();
			if (!_context.Products.Any())
			{
				CategoryModel Phone = new CategoryModel
				{
					Name = "Phone",
					Slug = "phone",
					Description = "1st",
					Status = 1
				};
				CategoryModel Conputer = new CategoryModel
				{
					Name = "Computer",
					Slug = "computer",
					Description = "2st",
					Status = 1
				};

				BrandModel Apple = new BrandModel
				{
					Name = "Apple",
					Slug = "apple",
					Description = "1st",
					Status = 1
				};
				BrandModel Samsung = new BrandModel
				{
					Name = "Samsung",
					Slug = "samsung",
					Description = "2st",
					Status = 1
				};

				_context.Products.AddRange(
					new ProductModel
					{
						Name = "Iphone 16 Promax",
						Slug = "Iphone16promax",
						Description = "1st",
						Image = "1.jpg",
						Category = Phone,
						Brand = Apple,
						Price = 999
					},
					new ProductModel
					{
						Name = "Samsung Y",
						Slug = "samsungy",
						Description = "2st",
						Image = "2.jpg",
						Category = Phone,
						Brand = Samsung,
						Price = 888
					}
				);
				_context.SaveChanges();
			}
		}
	}
}
