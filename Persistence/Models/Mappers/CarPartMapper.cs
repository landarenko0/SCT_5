using Core.Models;
using Persistence.Models;

namespace Persistence.Models.Mappers
{
    internal static class CarPartMapper
    {
        internal static CarPart ToDomain(this CarPartDto carPart) => new()
        {
            Id = carPart.Id,
            Title = carPart.Title,
            Quantity = carPart.Quantity
        };

        internal static CarPartDto ToDto(this CarPart carPart) => new()
        {
            Id = carPart.Id,
            Title = carPart.Title,
            Quantity = carPart.Quantity
        };
    }
}