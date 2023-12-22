namespace TrafficLightsController;

public interface ICrossroad
{
    public Direction AllowedDirection { get; }
    public void ChangeAllowedDirection();
}