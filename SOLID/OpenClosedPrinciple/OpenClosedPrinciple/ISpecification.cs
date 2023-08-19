using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosedPrinciple
{
    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }
}
