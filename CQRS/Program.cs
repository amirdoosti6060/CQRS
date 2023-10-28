using CQRS;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddScoped<IOrderMateralizedView, OrderMateralizedView>()
    .AddScoped<OrderRepository>()
    .AddScoped<OrderCommandHandler>()
    .AddScoped<OrderQueryHandler>()
    .BuildServiceProvider();

// Create a command
var createOrderCommand = new CreateOrderCommand
{
    CustomerName = "Amir Doosti",
    Product = "Product-1"
};

Console.WriteLine("CQRS in action");

Console.WriteLine($"\nWe sent an 'Command' to add an order: ");
Console.WriteLine( $"Order-Id={createOrderCommand.CustomerName}, " +
    $"Product={createOrderCommand.Product}");

var orderCommandHandler = serviceProvider.GetService<OrderCommandHandler>();
orderCommandHandler.Handle(createOrderCommand);

// Create a query
var getOrderQuery = new GetOrderQuery { OrderId = 1 };

Console.WriteLine($"\nNow we create a 'Query' from materialized view:");
Console.WriteLine($"Order-Id={getOrderQuery.OrderId}");

var orderQueryHandler = serviceProvider.GetService<OrderQueryHandler>();
string result = orderQueryHandler.Handle(getOrderQuery);
Console.WriteLine("\nResult of query:");
// Order_Id: 1, Product: Product-1, Customer FirstName: Amir, Customer LastName: Doosti
Console.WriteLine(result);

