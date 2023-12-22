namespace TrafficLightsController.Crossroads;

public class Crossroad : ICrossroad
{
    private static int _crossroadCounter;
    
    public int CrossroadIndex { get; }
    public Direction AllowedDirection { get; private set; }
    public List<TrafficLight> HorizontalTrafficLights { get; }
    public List<TrafficLight> VerticalTrafficLights { get; }

    public Crossroad(
        List<TrafficLight> horizontalLights, 
        List<TrafficLight> verticalLights,
        Direction initialAllowedDirection = Direction.Horizontal)
    {
        CrossroadIndex = _crossroadCounter++;
        AllowedDirection = initialAllowedDirection;
        HorizontalTrafficLights = horizontalLights;
        VerticalTrafficLights = verticalLights;
        // Выставляем зелёный на правильных светофорах
        if (initialAllowedDirection == Direction.Horizontal)
        {
            foreach (var htl in HorizontalTrafficLights)
            {
                htl.ChangeLight();
            }
        }
        else
        {
            foreach (var vtl in VerticalTrafficLights)
            {
                vtl.ChangeLight();
            }
        }
    }

    public void ChangeAllowedDirection()
    {
        if (AllowedDirection == Direction.Horizontal)
        {
            ChangeAllowedDirection(VerticalTrafficLights, HorizontalTrafficLights, CrossroadIndex);
            AllowedDirection = Direction.Vertical;
        }
        else
        {
            ChangeAllowedDirection(HorizontalTrafficLights, VerticalTrafficLights, CrossroadIndex);
            AllowedDirection = Direction.Horizontal;
        }
    }

    private static void ChangeAllowedDirection(
        List<TrafficLight> greenLights, 
        List<TrafficLight> redLights, 
        int crossroadIndex)
    {
        // два for по причине, возможно, разного количества
        // светофоров в разные стороны 
        foreach (var t in greenLights)
        {
            if (t.IsGreen) 
                throw new InvalidOperationException($"На перекрёстке с индексом {crossroadIndex} светофор уже " +
                                                    "горит зелёным в эту сторону!");
            t.ChangeLight();
        }

        foreach (var t in redLights)
        {
            if (!t.IsGreen)
                throw new InvalidOperationException($"На перекрёстке с индексом {crossroadIndex} светофор уже " +
                                                    "горит красным в эту сторону!");
            t.ChangeLight();
        }
    }
}