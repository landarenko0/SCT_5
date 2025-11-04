using Application.ViewModels;
using Core.Models;
using Core.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SCT_5.Forms;

namespace SCT_5.Factories
{
    public class CarPartFormFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public CarPartFormFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public CarPartForm CreateForm(Action onSaveButtonClick)
        {
            var carPartsRepository = _serviceProvider.GetRequiredService<ICarPartsRepository>();
            var logger = _serviceProvider.GetRequiredService<ILogger<CarPartViewModel>>();
            var viewModel = new CarPartViewModel(carPartsRepository, logger);

            return new CarPartForm(viewModel, onSaveButtonClick);
        }

        public CarPartForm CreateForm(Action onSaveButtonClick, CarPart carPart)
        {
            var carPartsRepository = _serviceProvider.GetRequiredService<ICarPartsRepository>();
            var logger = _serviceProvider.GetRequiredService<ILogger<CarPartViewModel>>();
            var viewModel = new CarPartViewModel(carPartsRepository, logger);

            return new CarPartForm(viewModel, carPart, onSaveButtonClick);
        }
    }
}