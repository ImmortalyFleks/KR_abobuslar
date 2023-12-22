namespace TrafficLightsController;

public abstract class TrafficLight
{
    public Guid TrafficLightId { get; protected set; }
    
    public bool IsGreen { get; protected set; }
    
    public virtual void ChangeLight()
    {
        IsGreen = !IsGreen;
    }
}