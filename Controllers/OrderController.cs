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


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            try
            {
                var result = await _amiingTeknik.GetSingel(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error To get Data from DB");
            }
        }


        [HttpPost]
        public async Task<ActionResult<Order>> CreateNewOrder(Order NewOrder)
        {
            try
            {
                if(NewOrder == null)
                {
                    return BadRequest();
                }
                var CreatedOrder = await _amiingTeknik.Add(NewOrder);
                return CreatedAtAction(nameof(GetOrder), new { id = CreatedOrder.OrderId }, CreatedOrder);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error To Post Data To DB");
            }
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> DeleteOrder(int id)
        {
            try
            {
                var orderTodelete = await _amiingTeknik.GetSingel(id);
                if (orderTodelete == null)
                {
                    return NotFound($"Order with ID {id} not Founded ......");
                }
                return await _amiingTeknik.Delete(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error To Delete Data from DB");
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Order>> UpdateOrder(int id, Order order)
        {
            try
            {
                if(id != order.OrderId)
                {
                    return BadRequest("Order is not Match...");
                }

                var orderToUpdate = await _amiingTeknik.GetSingel(id);
                if(orderToUpdate == null)
                {
                    return NotFound($"Order with ID {id} not Founded....");
                }
                return await _amiingTeknik.Update(order);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error To Update Data  ");
            }
        }
    }
}
