using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS
{
    public class OrderRepository
    {
        private List<Order> orders;
        private IOrderMateralizedView materializedView;

        public OrderRepository(IOrderMateralizedView _materalizedView)
        {
            orders = new List<Order>();
            materializedView = _materalizedView;
        }

        public void AddOrder(Order order)
        {
            var ord = orders.Where(o => o.Id == order.Id).FirstOrDefault();

            if (ord != null)
            {
                UpdateOrder(order);
                materializedView.Update(order);
            }
            else
            {
                orders.Add(order);
                materializedView.Add(order);
            }
        }

        public void UpdateOrder(Order order)
        {
            var ord = orders.Where(o => o.Id == order.Id).FirstOrDefault();

            if (ord != null)
            {
                ord.Product = order.Product;
                ord.CustomerName = order.CustomerName;
                materializedView.Update(order);
            }
        }

        public void DeleteOrder(Order order)
        {
            orders.Remove(order);
            materializedView.Delete(order);
        }

        IEnumerable<Order> QueryOrder()
        {
            return orders;
        }
    }
}
