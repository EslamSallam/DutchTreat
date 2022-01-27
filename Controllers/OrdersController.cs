using DutchTreat.Data.Entities;
using DutchTreat.Data.Repos;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchTreat.Controllers
{
    [Route("api/[Controller]")]
    public class OrdersController : Controller
    {
        private readonly IRepoDutch<Order> _OrdersRepo;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IRepoDutch<Order> OrdersRepo,ILogger<OrdersController> logger)
        {
            _OrdersRepo = OrdersRepo;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get()
        {
            try
            {
                return Ok(_OrdersRepo.List());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get Orders {ex}");
                return BadRequest($"Failed to get orders");
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<Order> Get(int id)
        {
            try
            {
                var order = _OrdersRepo.GetElementById(id);
                if (order != null)
                {
                    return Ok(order);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get Orders {ex}");
                return BadRequest($"Failed to get orders");
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody]OrdersViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newOrder = new Order()
                    {
                        OrderNumber = model.orderNumber,
                        OrderDate = model.orderDate
                    };
                    if (newOrder.OrderDate == DateTime.MinValue)
                    {
                        newOrder.OrderDate = DateTime.Now;
                    }
                    _OrdersRepo.AddEntity(newOrder);

                    if (_OrdersRepo.SaveAll())
                    {
                        var vm = new OrdersViewModel()
                        {
                            orderId = newOrder.Id,
                            orderDate = newOrder.OrderDate,
                            orderNumber = newOrder.OrderNumber
                        };
                        return Created($"Created the order api/Orders/{vm.orderId}", vm);
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to save a new order: {ex}");
            }
            return BadRequest($"Failed to create the order api/Orders/{model.orderId}");

        }

    }
}
