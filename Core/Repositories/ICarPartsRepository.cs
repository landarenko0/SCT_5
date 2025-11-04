using Core.Models;

namespace Core.Repositories
{
    public interface ICarPartsRepository
    {
        public Task<List<CarPart>> GetAllCarParts();
        public Task CreateCarPart(CarPart carPart);
        public Task UpdateCarPart(CarPart carPart);
        public Task DeleteCarPart(int carPartId);
    }
}