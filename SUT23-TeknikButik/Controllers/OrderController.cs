using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SUT23_TeknikButik.Services;
using SUT23_TeknikButikModels;

namespace SUT23_TeknikButik.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private ITeknikButik<Order> _teknikbutik;
        public OrderController(ITeknikButik<Order> teknikbutik)
        {
            _teknikbutik = teknikbutik;
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
              var CreatedOrder =  await _teknikbutik.Add(NewOrder);
                return CreatedAtAction(nameof(GetOrder),
                    new { id = CreatedOrder.OrderID }, CreatedOrder);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to Post Data To Database.......");
            }
        }

        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            return null;
        }
    }
}
