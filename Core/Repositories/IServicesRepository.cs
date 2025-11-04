using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
	public interface IServicesRepository
	{
		public Task<List<Service>> GetAllServices();

		public Task CreateService(Service service);

		public Task UpdateService(Service service);

		public Task DeleteService(int serviceId);
	}
}
