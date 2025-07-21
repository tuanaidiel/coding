//Create a model, controller, and API endpoint in ASP.NET Core for managing Patient Test Orders.

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

//model
namespace LisHisApi.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string PatientName { get; set; }
        public string TestType { get; set; }
        public DateTime OrderDate { get; set; }

    }
}

//controller
namespace LisHisApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private static readonly List<Order> _orders = new();
        private static int _nextId = 1;


        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetOrders()
        {
            return Ok(_orders);
        }


        [HttpPost]
        public ActionResult<Order> CreateOrder([FromBody] Order order)
        {
            if (string.IsNullOrEmpty(order.PatientName) || string.IsNullOrEmpty(order.TestType))
            {
                return BadRequest("PatientName and TestType are required.");
            }

            order.OrderId = _nextId;
            order.OrderDate = DateTime.UtcNow;
            _orders.Add(order);

            return CreatedAtAction(nameof(GetOrders), new { id = order.OrderId }, order);
        }

    }
}