using Core.Models;
using Core.Repositories;
using Microsoft.Extensions.Logging;

namespace Application.ViewModels
{
    public class CarPartsViewModel
    {
        private readonly ICarPartsRepository _carPartsRepository;
        private readonly ILogger _logger;

        private List<CarPart> _carParts = [];

        public event Action<List<CarPart>>? OnCarPartsChanged = null;
        public event Action<string>? OnError = null;
        public event Action<bool>? UpdateButtonsState = null;
        public event Action? ClearCarPartsTable = null;

        public CarPartsViewModel(ICarPartsRepository carPartsRepository, ILogger<CarPartsViewModel> logger)
        {
            _carPartsRepository = carPartsRepository;
            _logger = logger;

            Task.Run(async () =>
            {
                await UpdateCarPartsList();
                OnCarPartsChanged?.Invoke(_carParts);
                UpdateButtonsState?.Invoke(_carParts.Count > 0);
            });
        }

        public void OnDeleteCarPartConfirmed(int selectedIndex)
        {
            UpdateButtonsState?.Invoke(false);
            ClearCarPartsTable?.Invoke();

            Task.Run(async () =>
            {
                CarPart carPart = _carParts[selectedIndex];
                await DeleteCarPart(carPart);
                await UpdateCarPartsList();

                OnCarPartsChanged?.Invoke(_carParts);
                UpdateButtonsState?.Invoke(_carParts.Count > 0);
            });
        }

        private async Task DeleteCarPart(CarPart carPart)
        {
            try
            {
                await _carPartsRepository.DeleteCarPart(carPart.Id);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occured while DeleteCarPart() was executing");
                OnError?.Invoke("Произошла ошибка при удалении запчасти");
            }
        }

        private async Task UpdateCarPartsList()
        {
            try
            {
                _carParts = await _carPartsRepository.GetAllCarParts();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occured while UpdateCarPartsList() was executing");
                OnError?.Invoke("Произошла ошибка при загрузке запчастей");
            }
        }

        public void OnCarPartFormSaveButtonClicked()
        {
            ClearCarPartsTable?.Invoke();
            UpdateButtonsState?.Invoke(false);

            Task.Run(async () =>
            {
                await UpdateCarPartsList();
                OnCarPartsChanged?.Invoke(_carParts);
                UpdateButtonsState?.Invoke(_carParts.Count > 0);
            });
        }

        public CarPart? GetSelectedCarPart(int selectedIndex)
        {
            return selectedIndex >= 0 && selectedIndex < _carParts.Count ? _carParts[selectedIndex] : null;
        }
    }
}