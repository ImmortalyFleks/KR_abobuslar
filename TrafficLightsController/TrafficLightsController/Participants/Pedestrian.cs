namespace TrafficLightsController.Participants;

public class Pedestrian : ITrafficParticipant
{
    public string Name { get; }
    public bool IsCrossed { get; private set; }

    public Pedestrian(string name = "unknown")
    {
        Name = name;
        IsCrossed = false;
    } 
    
    public void Proceed()
    {
        IsCrossed = true;
        Console.WriteLine($"{Name} перешёл дорогу. ");
    }
}