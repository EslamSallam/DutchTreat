using DutchTreat.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchTreat.Data.Repos
{
    public class OrderRepo : IRepoDutchOrders
    {
        private readonly DutchContext _ctx;

        public OrderRepo(DutchContext ctx)
        {
            _ctx = ctx;
        }

        public void AddEntity(Order model)
        {
            _ctx.orders.Add(model);
        }

        public Order GetElementById(int id)
        {
            return _ctx.orders.Include(o => o.Items).ThenInclude(i => i.Product).Where(o => o.Id == id).FirstOrDefault();
        }

        public List<Order> List(bool includeItems = true)
        {
            if (includeItems)
            {
                return _ctx.orders.Include(o => o.Items).ThenInclude(i => i.Product).ToList();
            }
            else
            {
                return _ctx.orders.ToList();
            }
        }

        public List<Order> List()
        {
            return List();
        }

        public List<Order> ListFilter(Func<Order, bool> lambda)
        {
            return _ctx.orders.Include(o => o.Items).ThenInclude(i => i.Product).Where(lambda).ToList();
        }

        public bool SaveAll()
        {
          return _ctx.SaveChanges() > 0;
        }
    }
}
