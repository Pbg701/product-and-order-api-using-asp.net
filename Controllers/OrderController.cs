using Microsoft.AspNetCore.Mvc;
using MyApi.Models;
using MyApi.Repository;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IRepository _repo;

        public OrderController(IRepository repo)
        {
            _repo = repo;
        }

        // ✅ GET ALL ORDERS
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var data = _repo.GetAllOrders();

                if (data == null || data.Count == 0)
                {
                    return NotFound(new { message = "No orders found" });
                }

                return Ok(new
                {
                    message = "Orders fetched successfully",
                    data = data
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Something went wrong",
                    error = ex.Message
                });
            }
        }

        // ✅ GET BY ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var order = _repo.GetOrderById(id);

            if (order == null)
                return NotFound(new { message = "Order not found" });

            return Ok(order);
        }

        // ✅ ADD ORDER
        [HttpPost]
        public IActionResult Add(Order order)
        {
            try
            {
                if (order == null || string.IsNullOrEmpty(order.CustomerName))
                {
                    return BadRequest(new { message = "Invalid order data" });
                }

                _repo.AddOrder(order);

                return Ok(new
                {
                    message = "Order added successfully",
                    data = order
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Error while adding order",
                    error = ex.Message
                });
            }
        }

        // ✅ UPDATE ORDER
        [HttpPut("{id}")]
        public IActionResult Update(int id, Order order)
        {
            try
            {
                var existing = _repo.GetOrderById(id);

                if (existing == null)
                {
                    return NotFound(new { message = "Order not found" });
                }

                _repo.UpdateOrder(id, order);

                return Ok(new { message = "Order updated successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Error while updating order",
                    error = ex.Message
                });
            }
        }

        // ✅ DELETE ORDER
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var existing = _repo.GetOrderById(id);

                if (existing == null)
                {
                    return NotFound(new { message = "Order not found" });
                }

                _repo.DeleteOrder(id);

                return Ok(new { message = "Order deleted successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Error while deleting order",
                    error = ex.Message
                });
            }
        }
    }
}