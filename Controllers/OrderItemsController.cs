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
    [Route("api/Orders/{OrderId}/Items")]
    public class OrderItemsController : Controller
    {
        private readonly IRepoDutchOrders _ordersRepo;
        private readonly ILogger<OrderItemsController> _logger;
        private readonly IMapper _mapper;

        public OrderItemsController(IRepoDutchOrders OrdersRepo,ILogger<OrderItemsController> logger,IMapper mapper)
        {
            _ordersRepo = OrdersRepo;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult Get(int OrderId)
        {
            var result = _ordersRepo.GetElementById(OrderId).Items.ToList();
            if (result != null)
            {
                return Ok(_mapper.Map<IEnumerable<OrderItemsViewModel>>(result));
            }
            return NotFound();
        }
        [HttpGet("{id}")]
        public ActionResult Get(int OrderId,int id)
        {
            var result = _ordersRepo.GetElementById(OrderId);
            if (result != null)
            {
                var item = result.Items.Where(i => i.Id == id).FirstOrDefault();
                return Ok(_mapper.Map<OrderItemsViewModel>(item));
            }
            return NotFound();
        }
    }
}
