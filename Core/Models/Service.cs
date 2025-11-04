using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
	public class Service
	{
		public int Id { get; set; }

		public string Title { get; set; } = null!;

		public int Price { get; set; }
	}
}
