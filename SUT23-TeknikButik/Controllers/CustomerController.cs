using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using SUT23_TeknikButik.Services;

namespace SUT23_TeknikButik.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomer _customer;
        public CustomerController(ICustomer customer)
        {
            _customer = customer;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            try
            {
               return Ok(await _customer.GetAllCustomers());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error to get Data from Database.......");
            }
        }


        [HttpGet("{id:int}")]
        public async Task <IActionResult> GetCustomer(int id)
        {
            try
            {
                var result = await _customer.GetSingelCustomer(id);
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound($"Customer with ID {id} Not Founded");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            

            
        }


        [HttpGet("search")]
        public async Task<IActionResult> Search(string name)
        {
            try
            {
                var result = await _customer.Search(name);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            
        }
    }
}
