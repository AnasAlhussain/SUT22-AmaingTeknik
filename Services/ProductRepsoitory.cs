using AmazingTeknikModels;
using Microsoft.EntityFrameworkCore;
using SUT22_AmaingTeknik.Models;

namespace SUT22_AmaingTeknik.Services
{
    public class ProductRepsoitory :IAmazingTeknik<Product>
    {
        private AppDbContex _appContext;
        public ProductRepsoitory(AppDbContex appDbContex)
        {
            this._appContext = appDbContex;
        }

        public async Task<Product> Add(Product newEntity)
        {
          var result =  await _appContext.Products.AddAsync(newEntity);
            await _appContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Product> Delete(int id)
        {

          var result =  await _appContext.Products.FirstOrDefaultAsync(p => p.ProductId == id);
            if (result != null)
            {
                _appContext.Products.Remove(result);
                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _appContext.Products.ToListAsync();
        }

        public async Task<Product> GetSingel(int id)
        {
            return await _appContext.Products.FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task<Product> Update(Product entity)
        {
            var result = await _appContext.Products.FirstOrDefaultAsync(p => p.ProductId == entity.ProductId);
            if(result != null)
            {
                result.ProductName = entity.ProductName;
                result.Price = entity.Price;
                result.Category = entity.Category;

                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
