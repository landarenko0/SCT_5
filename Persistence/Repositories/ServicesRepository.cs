using Core.Models;
using Core.Repositories;
using Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Persistence.Models.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
	public class ServicesRepository(IDbContextFactory<CarServiceContext> contextFactory) : IServicesRepository
	{
		public async Task CreateService(Service service)
		{
			await using CarServiceContext context = await contextFactory.CreateDbContextAsync();

			await context.Services.AddAsync(service.ToDto());
			await context.SaveChangesAsync();
		}

		public async Task UpdateService(Service service)
		{
			await using CarServiceContext context = await contextFactory.CreateDbContextAsync();

			await context.Services
				.Where(e => e.Id == service.Id)
				.ExecuteUpdateAsync(propertyCalls => propertyCalls
					.SetProperty(e => e.Title, service.Title)
					.SetProperty(e => e.Price, service.Price)
				);
		}

		public async Task DeleteService(int serviceId)
		{
			await using CarServiceContext context = await contextFactory.CreateDbContextAsync();
			await context.Services.Where(e => e.Id == serviceId).ExecuteDeleteAsync();
		}

		public async Task<List<Service>> GetAllServices()
		{
			await using CarServiceContext context = await contextFactory.CreateDbContextAsync();

			return await context.Services
				.AsNoTracking()
				.OrderBy(e => e.Id)
				.Select(e => e.ToDomain())
				.ToListAsync();
		}
	}
}
