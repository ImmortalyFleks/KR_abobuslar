namespace TrafficLightsController.Participants;

public class Transport : ITrafficParticipant
{
    public string TransportNumber { get; }
    public bool IsCrossed { get; private set; }

    public Transport(string transportNumber = "A000AA")
    {
        TransportNumber = transportNumber;
        IsCrossed = false;
    }
    
    public void Proceed()
    {
        IsCrossed = true;
        Console.WriteLine($"Транспорт с номером {TransportNumber} переехал дорогу. ");
    }
}