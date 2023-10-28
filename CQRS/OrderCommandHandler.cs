using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS
{
    public class OrderCommandHandler
    {
        private readonly OrderRepository _orderRepository;
        private int _orderId = 1;

        public OrderCommandHandler(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void Handle(CreateOrderCommand command)
        {
            // Perform validation and business logic
            var order = new Order
            {
                Id = _orderId++,
                CustomerName = command.CustomerName,
                Product = command.Product
            };

            _orderRepository.AddOrder(order);
        }
    }
}
