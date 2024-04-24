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
                if (NewOrder == null)
                {
                    return BadRequest();
                }
                var CreatedOrder = await _teknikbutik.Add(NewOrder);
                return CreatedAtAction(nameof(GetOrder),
                    new { id = CreatedOrder.OrderID }, CreatedOrder);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to Post Data To Database.......");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
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
                    "Error to Retrive Data from Database.......");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                return Ok(await _teknikbutik.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error to get Data from Database.......");
            }
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Order>> DeleteOrder(int id)
        {
            try
            {
                var orderToDelete = await _teknikbutik.GetSingel(id);
                if (orderToDelete == null)
                {
                    return NotFound($"Order with ID {id} not founded to delete..");
                }
                return await _teknikbutik.Delete(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error to Delete Data from Database.......");
            }
          
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Order>> UpdateOrder(int id,Order order)
        {
            try
            {
                if(id != order.OrderID)
                {
                    return BadRequest("Order is not matching....");
                }

                var orederTUpdate = await _teknikbutik.GetSingel(id);
                if(orederTUpdate == null)
                {
                    return NotFound($"Order With ID {id} Not Founded");
                }
                return await _teknikbutik.Update(order);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to Update Data in the Database.......");
            }
        }
    }
}
