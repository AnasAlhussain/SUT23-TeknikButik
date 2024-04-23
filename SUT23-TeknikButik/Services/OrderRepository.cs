using Microsoft.EntityFrameworkCore;
using SUT23_TeknikButik.Data;
using SUT23_TeknikButikModels;

namespace SUT23_TeknikButik.Services
{
    public class OrderRepository : ITeknikButik<Order>
    {
        private AppDbContext _appDbContext;
        public OrderRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<Order> Add(Order newEntity)
        {
           var result = await _appDbContext.Orders.AddAsync(newEntity);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Order> Delete(int id)
        {
            var result = await _appDbContext.Orders.
                FirstOrDefaultAsync(o => o.OrderID == id);
            if(result != null)
            {
                _appDbContext.Orders.Remove(result);
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public Task<IEnumerable<Order>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetSingel(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Order> Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
