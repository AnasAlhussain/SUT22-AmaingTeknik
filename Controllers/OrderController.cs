using AmazingTeknikModels;
using Microsoft.AspNetCore.Mvc;
using SUT22_AmaingTeknik.Services;

namespace SUT22_AmaingTeknik.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IAmazingTeknik<Order> _amiingTeknik;
        public OrderController(IAmazingTeknik<Order> amazingTeknik)
        {
            this._amiingTeknik = amazingTeknik;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                return Ok(await _amiingTeknik.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error To get Data from DB");
            }
        }
    }
}
