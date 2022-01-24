using DutchTreat.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchTreat.Data.Repos
{
    public class OrderRepo : IRepoDutch<Order>
    {
        private readonly DutchContext _ctx;

        public OrderRepo(DutchContext ctx)
        {
            _ctx = ctx;
        }
        public List<Order> List()
        {
           return _ctx.orders.ToList();
        }

        public List<Order> ListFilter(Func<Order, bool> lambda)
        {
            return _ctx.orders.Where(lambda).ToList();
        }
    }
}
