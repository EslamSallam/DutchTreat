using DutchTreat.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchTreat.Data.Repos
{
    public class ProductRepo : IRepoDutch<Product>
    {
        private readonly DutchContext _ctx;

        public ProductRepo(DutchContext ctx)
        {
            _ctx = ctx;
        }

        public Product GetElementById(int id)
        {
            return _ctx.products.Where(p => p.Id == id).FirstOrDefault();
        }

        public List<Product> List()
        {
           return _ctx.products.OrderBy(p => p.Title).ToList();
        }

        public List<Product> ListFilter(Func<Product, bool> lambda)
        {
            return _ctx.products.Where(lambda).ToList();
        }
    }
}
