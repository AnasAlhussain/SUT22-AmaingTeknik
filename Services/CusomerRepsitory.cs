using AmazingTeknikModels;
using SUT22_AmaingTeknik.Models;

namespace SUT22_AmaingTeknik.Services
{
    public class CusomerRepsitory : ICustomerRepository
    {
        private AppDbContex _appDbContext;
        public CusomerRepsitory(AppDbContex appDbContex)
        {
            this._appDbContext = appDbContex;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _appDbContext.Customers;
        }

        public Customer GetSingleCusomer(int id)
        {
            return _appDbContext.Customers.FirstOrDefault(c => c.CustomerId == id);
        }

        public IEnumerable<Customer> Search(string name)
        {
           IQueryable<Customer> query =  _appDbContext.Customers;
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(c => c.FirstName.Contains(name) || c.LastName.Contains(name));
            }
            return query.ToList();
        }
    }
}
