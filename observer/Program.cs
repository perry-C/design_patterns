namespace observer;

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Observer";
        OrderService orderService = new();
        TicketResellerService ticketResellerService = new();
        TicketStockService ticketStockService = new();

        orderService.AddObserver(ticketStockService);
        orderService.AddObserver(ticketResellerService);

        orderService.CompleteTicketSale(1, 200);

        orderService.CompleteTicketSale(2, 400);

        Console.ReadKey();
    }
}
