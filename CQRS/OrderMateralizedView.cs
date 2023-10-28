using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS
{
    public class OrderMateralizedView: IOrderMateralizedView
    {
        List<OrderView> orders;

        public OrderMateralizedView()
        {
            orders = new List<OrderView>();
        }

        public void Add(Order t)
        {
            var ord = orders.Where(o => o.Id == t.Id).FirstOrDefault();

            if (ord != null)
                Update(t);
            else
            {
                string[] spl = t.CustomerName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries|StringSplitOptions.TrimEntries);
                string firstName = spl.Count() > 0 ? spl[0]: "";
                string lastName = spl.Count() > 1 ? spl[1] : "";

                var ordView = new OrderView
                {
                    Id = t.Id,
                    Product = t.Product,
                    CustomerFirstName = firstName,
                    CustomerLastName = lastName
                };
                orders.Add(ordView);
            }
        }

        public void Delete(Order t)
        {
            var ord = orders.Where(o => o.Id == t.Id).FirstOrDefault();
            if (ord != null)
                orders.Remove(ord);
        }

        public void Update(Order t)
        {
            var ord = orders.Where(o => o.Id == t.Id).FirstOrDefault();

            if (ord != null)
            {
                string[] spl = t.CustomerName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                string firstName = spl.Count() > 0 ? spl[0] : "";
                string lastName = spl.Count() > 1 ? spl[1] : "";

                ord.Product = t.Product;
                ord.CustomerFirstName = firstName;
                ord.CustomerLastName = lastName;
            }
        }

        public IEnumerable<OrderView> QueryList()
        {
            return orders;
        }
    }
}
