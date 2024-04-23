using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SUT23_TeknikButik.Services;
using SUT23_TeknikButikModels;

namespace SUT23_TeknikButik.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ITeknikButik<Product> _teknikbutik;

        public ProductController(ITeknikButik<Product> teknikbutik)
        {
            _teknikbutik = teknikbutik;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            try
            {
                return Ok(await _teknikbutik.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to retrive data from Database......");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            try
            {
                var result = await _teknikbutik.GetSingel(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to retrive data from Database......");
            }
        }


        [HttpPost]
        public async Task<ActionResult<Product>> CreateNewProduct(Product newPro)
        {
            try
            {
                if(newPro == null)
                {
                    return BadRequest();
                }
                var createdProduct = await _teknikbutik.Add(newPro);
                return CreatedAtAction(nameof(GetProduct),
                    new { id = createdProduct.ProductId }, createdProduct);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to Create data in the Database......");
            }
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            try
            {
               var productToDelete = await _teknikbutik.GetSingel(id);
                if(productToDelete == null)
                {
                    return NotFound($"Product With ID {id} Not Founded To Delete....");
                }
                return await _teknikbutik.Delete(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to Delete data from Database......");
            }
        }



        [HttpPut("{id:int}")]
        public async Task<ActionResult<Product>> UpdateProduct(int id,Product pro)
        {
            try
            {
                if(id != pro.ProductId)
                {
                    return BadRequest("Product ID Dosen't matching ....");
                }
               var productToUpdate = await _teknikbutik.GetSingel(id);
                if(productToUpdate == null)
                {
                    return NotFound($"Product With ID {id} Not Founded To Update ....");
                }
                return await _teknikbutik.Update(pro);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to Update data into Database......");
            }
        }
    }
}
