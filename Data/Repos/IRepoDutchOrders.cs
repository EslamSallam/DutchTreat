using DutchTreat.Data.Entities;
using System.Collections.Generic;

namespace DutchTreat.Data.Repos
{
    public interface IRepoDutchOrders : IRepoDutch<Order>
    {
        public List<Order> List(bool includeItems);  
    }
}
