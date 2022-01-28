using AutoMapper;
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
        private readonly IMapper _mapper;

        public OrdersController(IRepoDutch<Order> OrdersRepo,ILogger<OrdersController> logger,IMapper mapper)
        {
            _OrdersRepo = OrdersRepo;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get()
        {
            try
            {
                var result = _OrdersRepo.List();
                return Ok(_mapper.Map<IEnumerable<OrdersViewModel>>(result));
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
                    return Ok(_mapper.Map<OrdersViewModel>(order));
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
                    var newOrder = _mapper.Map<Order>(model);
                    if (newOrder.OrderDate == DateTime.MinValue)
                    {
                        newOrder.OrderDate = DateTime.Now;
                    }
                    _OrdersRepo.AddEntity(newOrder);

                    if (_OrdersRepo.SaveAll())
                    {
                        var vm = _mapper.Map<OrdersViewModel>(newOrder);
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
