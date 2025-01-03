using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModel.ViewModels
{
	public class CartItemViewModel
	{
		public List<CartItemModel> CartItems { get; set; }
		public decimal GrandTotal { get; set; }
	}
}
