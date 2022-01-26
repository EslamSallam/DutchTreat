using DutchTreat.Data.Entities;
using DutchTreat.Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchTreat.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductsController : Controller
    {
        private readonly IRepoDutch<Product> _repository;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IRepoDutch<Product> ProductRepo,ILogger<ProductsController> logger)
        {
            _repository = ProductRepo;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
       public ActionResult<IEnumerable<Product>> Get()
        {
            try
            {
                return Ok(_repository.List());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get products: {ex}");
                return BadRequest("Faild to get products");
            }

        }
    }
}
