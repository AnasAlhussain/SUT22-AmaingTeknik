using AmazingTeknikModels;
using Microsoft.EntityFrameworkCore;
using SUT22_AmaingTeknik.Models;

namespace SUT22_AmaingTeknik.Services
{
    public class OrderRepository : IAmazingTeknik<Order>
    {
        private AppDbContex _appDbContext;
        public OrderRepository(AppDbContex appDbContex)
        {
            this._appDbContext = appDbContex;
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
                FirstOrDefaultAsync(o => o.OrderId == id);
            if (result != null)
            {
                _appDbContext.Orders.Remove(result);
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _appDbContext.Orders.Include(o => o.Customer).ToListAsync();
        }

        public async Task<Order> GetSingel(int id)
        {
            return await _appDbContext.Orders.
                Include(o => o.Customer).FirstOrDefaultAsync(o => o.OrderId == id);
        }

        public async Task<Order> Update(Order entity)
        {
            var result = await _appDbContext.Orders.
                FirstOrDefaultAsync(o => o.OrderId == entity.OrderId);

            if (result != null)
            {
                result.OrderPlaced = entity.OrderPlaced;
                result.Customer.Address = entity.Customer.Address;
                result.Customer.Email = entity.Customer.Email;

                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
