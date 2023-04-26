using AmazingTeknikModels;
using Microsoft.AspNetCore.Mvc;
using SUT22_AmaingTeknik.Services;

namespace SUT22_AmaingTeknik.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IAmazingTeknik<Product> _amazingteknik;
        
        public ProductController(IAmazingTeknik<Product> amazingTeknik)
        {
            this._amazingteknik = amazingTeknik;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            try
            {
                return Ok(await _amazingteknik.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, 
                    "Error to retriev dara from Database....");
            }
            
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            try
            {
                var result = await _amazingteknik.GetSingel(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to retriev dara from Database....");
            }
        }


        [HttpPost]
        public async Task<ActionResult<Product>> CreateNewProduct(Product newPro)
        {
            try
            {
                if (newPro == null)
                {
                    return BadRequest();
                }
                var creatProduct = await _amazingteknik.Add(newPro);
                return CreatedAtAction(nameof(GetProduct),
                    new { id = creatProduct.ProductId }, creatProduct);
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            try
            {
                var productToDelete = await _amazingteknik.GetSingel(id);
                if (productToDelete == null)
                {
                    return NotFound($"Prduct with ID {id} Not Founded to Delete .....");
                }
                return await _amazingteknik.Delete(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error To delete from Database....");
            }
        }


        [HttpPut("id")]
        public async Task<ActionResult<Product>> UpdateProduct(int id , Product pro)
        {
            try
            {
                if (id != pro.ProductId)
                {
                    return BadRequest("Product ID Dosn't matching.....");
                }
                var productToUpdate = await _amazingteknik.GetSingel(id);
                if (productToUpdate == null)
                {
                    return NotFound($"Product With ID {id} Not Founded To Update..");
                }
                return await _amazingteknik.Update(pro);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error To Update To  Database....");
            }
        }

    }
}
