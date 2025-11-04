using Core.Models;
using Core.Repositories;
using Microsoft.Extensions.Logging;

namespace Application.ViewModels
{
    public class CarPartViewModel(ICarPartsRepository carPartsRepository, ILogger<CarPartViewModel> logger)
    {
        public event Action<string>? OnError = null;
        public event Action? OnCloseForm = null;
        public event Action<bool>? UpdateButtonState = null;

        public CarPart? CarPart { get; set; }

        public static string RandomTitle
        {
            get
            {
                List<string> titles = ["Тормозные колодки", "Масляный фильтр", "Свечи зажигания", "Воздушный фильтр", "Ремень ГРМ"];
                return titles[new Random().Next(titles.Count)];
            }
        }

        public static int RandomQuantity => new Random().Next(1, 100);

        private const string QuantityConstraintPgExceptionCode = "23514";

        public void OnSaveButtonClick(string title, string quantity)
        {
            if (!ValidateInput(title, quantity)) return;

            UpdateButtonState?.Invoke(false);

            CarPart carPart = new()
            {
                Title = title,
                Quantity = int.Parse(quantity)
            };

            Task.Run(async () =>
            {
                if (CarPart is null)
                {
                    if (await CreateCarPart(carPart)) OnCloseForm?.Invoke();
                }
                else
                {
                    carPart.Id = CarPart.Id;
                    if (await UpdateCarPart(carPart)) OnCloseForm?.Invoke();
                }

                UpdateButtonState?.Invoke(true);
            });
        }

        private bool ValidateInput(string title, string quantity)
        {
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrEmpty(title))
            {
                OnError?.Invoke("Введите название запчасти");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(quantity) || string.IsNullOrEmpty(quantity))
            {
                OnError?.Invoke("Введите количество");
                return false;
            }
            else if (!int.TryParse(quantity, out int result)) // Проверка на число
            {
                OnError?.Invoke("Некорректное количество");
                return false;
            }

            return true;
        }

        private async Task<bool> CreateCarPart(CarPart carPart)
        {
            try
            {
                await carPartsRepository.CreateCarPart(carPart);
                return true;
            }
            catch (Exception e)
            {
                logger.LogError(e, "An error occured while CreateCarPart() was executing");

                if (CheckExceptionContainsCode(e, QuantityConstraintPgExceptionCode))
                {
                    OnError?.Invoke("Количество не может быть отрицательным");
                }
                else OnError?.Invoke("Произошла ошибка");

                return false;
            }
        }

        private async Task<bool> UpdateCarPart(CarPart carPart)
        {
            try
            {
                await carPartsRepository.UpdateCarPart(carPart);
                return true;
            }
            catch (Exception e)
            {
                logger.LogError(e, "An error occured while UpdateCarPart() was executing");

                if (CheckExceptionContainsCode(e, QuantityConstraintPgExceptionCode))
                {
                    OnError?.Invoke("Количество не может быть отрицательным");
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