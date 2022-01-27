using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchTreat.Data.Repos
{
    public interface IRepoDutch<T>
    {
        public List<T> List();

        public List<T> ListFilter(Func<T, bool> lambda);
        public T GetElementById(int id);
    }
}
