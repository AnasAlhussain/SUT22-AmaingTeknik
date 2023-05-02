using AmazingTeknikModels;

namespace SUT22_AmaingTeknik.Services
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetSingleCusomer(int id);
        IEnumerable<Customer> Search(string name);
    }
}
