using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto1NET.Model;

namespace Proyecto1NET.Controller
{
	public class Controller
	{

		public string[] products { get; set; }

		public Controller(string[] products)
		{
			this.products = products;
		}

		public string[] GetProducts()
		{
			return new string[0];
		}

	}
}
