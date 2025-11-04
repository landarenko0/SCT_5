using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Persistence.Context;
using Persistence.Models;
using Persistence.Models.Mappers;

namespace Persistence.Repositories
{
    public class CarPartsRepository : ICarPartsRepository
    {
        private readonly IDbContextFactory<CarServiceContext> _contextFactory;

        public CarPartsRepository(IDbContextFactory<CarServiceContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task CreateCarPart(CarPart carPart)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            await context.CarParts.AddAsync(carPart.ToDto());
            await context.SaveChangesAsync();
        }

        public async Task UpdateCarPart(CarPart carPart)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();

            var existing = await context.CarParts.FindAsync(carPart.Id);
            if (existing != null)
            {
                existing.Title = carPart.Title;
                existing.Quantity = carPart.Quantity;
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteCarPart(int carPartId)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();

            try
            {
                var part = await context.CarParts.FindAsync(carPartId);
                if (part != null)
                {
                    context.CarParts.Remove(part);
                    await context.SaveChangesAsync();
                }
            }
            catch (DbUpdateException ex) when (ex.InnerException is PostgresException pgEx && pgEx.SqlState == "23503")
            {
                throw new Exception("Нельзя удалить запчасть, так как она используется в заказах или перемещениях склада");
            }
        }

        public async Task<List<CarPart>> GetAllCarParts()
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            return await context.CarParts
                .AsNoTracking()
                .OrderBy(cp => cp.Id)
                .Select(cp => cp.ToDomain())
                .ToListAsync();
        }
    }
}