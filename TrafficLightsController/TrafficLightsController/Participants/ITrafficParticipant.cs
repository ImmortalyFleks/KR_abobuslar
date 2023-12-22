namespace TrafficLightsController.Participants;

public interface ITrafficParticipant
{
    public bool IsCrossed { get; }
    public void Proceed();
}