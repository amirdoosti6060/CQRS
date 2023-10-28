using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS
{
    public class Order
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public string CustomerName { get; set; }
    }
}
