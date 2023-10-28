using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS
{
    public interface IOrderMateralizedView
    {
        void Add(Order t);
        void Update(Order t);
        void Delete(Order t);
        IEnumerable<OrderView> QueryList();
    }
}
