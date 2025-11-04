using Application.ViewModels;
using Core.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SCT_5.Forms;

namespace SCT_5.Factories
{
    public class CarPartsFormFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public CarPartsFormFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public CarPartsForm CreateForm()
        {
            var carPartsRepository = _serviceProvider.GetRequiredService<ICarPartsRepository>();
            var logger = _serviceProvider.GetRequiredService<ILogger<CarPartsViewModel>>();
            var carPartFormFactory = _serviceProvider.GetRequiredService<CarPartFormFactory>();

            var viewModel = new CarPartsViewModel(carPartsRepository, logger);
            return new CarPartsForm(viewModel, carPartFormFactory);
        }
    }
}