using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Models
{
	internal class ServiceDto
	{
		internal int Id { get; set; }

		internal string Title { get; set; } = null!;

		internal int Price { get; set; }
	}
}
