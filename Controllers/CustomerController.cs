using AmazingTeknikModels;
using Microsoft.AspNetCore.Mvc;
using SUT22_AmaingTeknik.Services;

namespace SUT22_AmaingTeknik.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
        }


        [HttpGet]
        public IActionResult GetCusomers()
        {
            return Ok(_customerRepository.GetAllCustomers());
        }
        
        [HttpGet("{id:int}")]
        public IActionResult GetCustomer(int id)
        {
            var result = _customerRepository.GetSingleCusomer(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound($"Customer with {id} Not Founded");
        }


        [HttpGet("search")]
        public IActionResult Search(string name)
        {
            var searchresult = _customerRepository.Search(name);
            if (searchresult.Any())
            {
                return Ok(searchresult);
            }
            return NotFound();
        }
    }
}
