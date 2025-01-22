using Employee_Dapper_Example.Dtos;
using Employee_Dapper_Example.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Dapper_Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersServices _orderServices;
        public OrdersController(IOrdersServices orderServices)
        {
            _orderServices = orderServices;
        }

        [HttpPost]
        [Route("AddOrder")]
        public async Task<IActionResult> Post([FromBody] OrdersDto orderDetail)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var orderData = await _orderServices.AddOrder(orderDetail);
                    return StatusCode(StatusCodes.Status201Created, orderData);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Not Found");
            }
        }

        [HttpDelete]
        [Route("DeleteOrdersById/{orderid}")]
        public async Task<IActionResult> delete(int orderid)
        {
            if (orderid < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Bad request");
            }
            try
            {
                var orderData = await _orderServices.DeleteOrderById(orderid);
                if (orderData == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "orderData not found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, "deletedSuccessfully");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server not found");
            }
        }
        [HttpGet]
        [Route("GetOrders")]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                var orderData = await _orderServices.GetOrders();
                if (orderData == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Bad request");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, orderData);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpGet]
        [Route("GetOrderById/{orderid}")]
        public async Task<IActionResult> Get(int orderid)
        {
            if (orderid < 0)
            {
                StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var orderdata = await _orderServices.GetOrderById(orderid);
                return StatusCode(StatusCodes.Status200OK, orderdata);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server error");
            }
        }

        [HttpPut]
        [Route("UpdateOrder")]
        public async Task<IActionResult> put([FromBody]OrdersDto orderdetail)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Bad request");
                }
                else
                {
                    var orderData = await _orderServices.UpdateOrder(orderdetail);
                    return StatusCode(StatusCodes.Status200OK, orderData);
                }
            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
    }
}
