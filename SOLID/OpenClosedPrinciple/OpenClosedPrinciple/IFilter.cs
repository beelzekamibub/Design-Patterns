using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosedPrinciple
{
    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> Items, ISpecification<T> spec);
    }
}
