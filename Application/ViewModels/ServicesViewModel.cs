using Core.Models;
using Core.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
	public class ServicesViewModel
	{
		private readonly IServicesRepository _servicesRepository;

		private readonly ILogger _logger;

		private List<Service> _services = [];

		public event Action<List<Service>>? OnServicesChanged = null;

		public event Action<string>? OnError = null;

		public event Action<bool>? UpdateButtonsState = null;

		public event Action? ClearServicesTable = null;

		public ServicesViewModel(IServicesRepository servicesRepository, ILogger<ServicesViewModel> logger)
		{
			_servicesRepository = servicesRepository;
			_logger = logger;

			Task.Run(async () =>
			{
				await UpdateServicesList();

				OnServicesChanged?.Invoke(_services);
				UpdateButtonsState?.Invoke(_services.Count > 0);
			});
		}

		public void OnDeleteServiceConfirmed(int selectedIndex)
		{
			UpdateButtonsState?.Invoke(false);
			ClearServicesTable?.Invoke();

			Task.Run(async () =>
			{
				Service service = _services[selectedIndex];

				await DeleteService(service);
				await UpdateServicesList();

				OnServicesChanged?.Invoke(_services);
				UpdateButtonsState?.Invoke(_services.Count > 0);
			});
		}

		private async Task DeleteService(Service service)
		{
			try
			{
				await _servicesRepository.DeleteService(service.Id);
			}
			catch (Exception e)
			{
				_logger.LogError(e, "An error occured while DeleteEmployee() was executing");
				OnError?.Invoke("Произошла ошибка");
			}
		}

		private async Task UpdateServicesList()
		{
			try
			{
				_services = await _servicesRepository.GetAllServices();
			}
			catch (Exception e)
			{
				_logger.LogError(e, "An error occured while UpdateEmployeesList() was executing");
				OnError?.Invoke("Произошла ошибка");
			}
		}

		public void OnServiceFormSaveButtonClicked()
		{
			ClearServicesTable?.Invoke();
			UpdateButtonsState?.Invoke(false);

			Task.Run(async () =>
			{
				await UpdateServicesList();

				OnServicesChanged?.Invoke(_services);
				UpdateButtonsState?.Invoke(_services.Count > 0);
			});
		}

		public Service? GetSelectedService(int selectedIndex)
		{
			return selectedIndex >= 0 && selectedIndex < _services.Count ? _services[selectedIndex] : null;
		}
	}
}
