using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchTreat.Data.Repos
{
    interface IRepoDutch<T>
    {
        public List<T> List();

        public List<T> ListFilter(Func<T, bool> lambda);
    }
}
