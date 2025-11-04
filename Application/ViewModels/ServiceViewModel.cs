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
	public class ServiceViewModel(IServicesRepository servicesRepository, ILogger<ServiceViewModel> logger)
	{
		public event Action<string>? OnError = null;

		public event Action? OnCloseForm = null;

		public event Action<bool>? UpdateButtonState = null;

		public Service? Service { get; set; }

		public static string RandomTitle
		{
			get
			{
				return "Ваше название услуги";
			}
		}

		public static int RandomPrice => new Random().Next(2, 101) * 100;

		private const string AlreadyExistsPgExceptionCode = "23505";

		private const string PriceConstraintPgExceptionCode = "23514";

		public void OnSaveButtonClick(string title, string price)
		{
			if (!ValidateInput(title, price)) return;

			UpdateButtonState?.Invoke(false);

			Service service = new()
			{
				Title = title,
				Price = int.Parse(price)
			};

			Task.Run(async () =>
			{
				if (Service is null)
				{
					if (await CreateService(service)) OnCloseForm?.Invoke();
				}
				else
				{
					service.Id = Service.Id;
					if (await UpdateService(service)) OnCloseForm?.Invoke();
				}

				UpdateButtonState?.Invoke(true);
			});
		}

		private bool ValidateInput(string title, string price)
		{
			if (string.IsNullOrWhiteSpace(title) || string.IsNullOrEmpty(title))
			{
				OnError?.Invoke("Введите наименование услуги");
				return false;
			}
			else if (string.IsNullOrWhiteSpace(price) || string.IsNullOrEmpty(price))
			{
				OnError?.Invoke("Введите стоимость");
				return false;
			}
			else if (!int.TryParse(price, out int result) /*|| result <= 0*/) // Отключено для проверки ограничения в БД
			{
				OnError?.Invoke("Некорректная зарплата");
				return false;
			}

			return true;
		}

		private async Task<bool> CreateService(Service service)
		{
			try
			{
				await servicesRepository.CreateService(service);
				return true;
			}
			catch (Exception e)
			{
				logger.LogError(e, "An error occured while SaveService() was executing");

				if (CheckExceptionContainsCode(e, PriceConstraintPgExceptionCode))
				{
					OnError?.Invoke("Цена должна быть больше 0");
				}
				else OnError?.Invoke("Произошла ошибка");

				return false;
			}
		}

		private async Task<bool> UpdateService(Service service)
		{
			try
			{
				await servicesRepository.UpdateService(service);
				return true;
			}
			catch (Exception e)
			{
				logger.LogError(e, "An error occured while UpdateService() was executing");

				if (CheckExceptionContainsCode(e, PriceConstraintPgExceptionCode))
				{
					OnError?.Invoke("Цена должна быть больше 0");
				}
				else OnError?.Invoke("Произошла ошибка");

				return false;
			}
		}

		private static bool CheckExceptionContainsCode(Exception exception, string exceptionCode)
		{
			if (exception.Message.Contains(exceptionCode)) return true;
			else if (exception.InnerException is not null && exception.InnerException.Message.Contains(exceptionCode)) return true;

			return false;
		}
	}
}
