using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS
{
    public class OrderQueryHandler
    {
        private readonly IOrderMateralizedView _view;

        public OrderQueryHandler(IOrderMateralizedView view)
        {
            _view = view;
        }

        public string Handle(GetOrderQuery query)
        {
            // Perform query logic
            var ord = _view.QueryList().Where(o => o.Id == query.OrderId).FirstOrDefault();

            if (ord != null)
                return $"Order_Id: {ord.Id}, Product: {ord.Product}, Customer FirstName: {ord.CustomerFirstName}, Customer LastName: {ord.CustomerLastName}";

            return "Order not found.";
        }
    }
}
