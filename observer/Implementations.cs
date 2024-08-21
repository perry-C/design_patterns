namespace observer;
using System;
public class TicketChange
{

    public int Amount { get; private set; }
    public int ArtistId { get; private set; }

    public TicketChange(int artistId, int amount)
    {
        ArtistId = artistId;
        Amount = amount;
    }
}
/// <summary>
/// Subject
/// </summary>
public abstract class TicketChangeNotifier
{
    private List<ITicketChangeListener> _observers = new();
    public void AddObserver(ITicketChangeListener observer)
    {
        _observers.Add(observer);
    }
    public void Notify(TicketChange ticketChange)
    {
        foreach (var observer in _observers)
        {
            observer.ReceiveTicketChangeNotification(ticketChange);
        }
    }
}

/// <summary>
/// Observer
/// </summary>
public interface ITicketChangeListener
{
    void ReceiveTicketChangeNotification(TicketChange ticketChange);
}

/// <summary>
/// ConcreteSubject
/// </summary>
public class OrderService : TicketChangeNotifier
{
    public void CompleteTicketSale(int artistId, int amount)
    {
        // change local datastore. Datastore omitted
        Console.WriteLine($"{nameof(OrderService)} is changing its state");
        // notify observers
        Console.WriteLine($"{nameof(OrderService)} is notifying observers");
        Notify(new TicketChange(artistId, amount));
    }
}

/// <summary>
/// ConcreteObserver
/// </summary>
public class TicketResellerService : ITicketChangeListener
{
    public void ReceiveTicketChangeNotification(TicketChange ticketChange)
    {
        Console.WriteLine($"{nameof(TicketResellerService)} notified of ticket change: artist {ticketChange.ArtistId}, amount ${ticketChange.Amount}");
    }
}

/// <summary>
/// ConcreteObserver
/// </summary>
public class TicketStockService : ITicketChangeListener
{
    public void ReceiveTicketChangeNotification(TicketChange ticketChange)
    {
        Console.WriteLine($"{nameof(TicketStockService)} notified of ticket change: artist {ticketChange.ArtistId}, amount ${ticketChange.Amount}");
    }
}