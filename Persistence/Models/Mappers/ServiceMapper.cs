using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Models.Mappers
{
	internal static class ServiceMapper
	{
		internal static Service ToDomain(this ServiceDto service) => new()
		{
			Id = service.Id,
			Title = service.Title,
			Price = service.Price
		};

		internal static ServiceDto ToDto(this Service service) => new()
		{
			Id = service.Id,
			Title = service.Title,
			Price = service.Price
		};
	}
}
