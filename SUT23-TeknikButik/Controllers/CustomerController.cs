using Microsoft.AspNetCore.Http;
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
    }
}
