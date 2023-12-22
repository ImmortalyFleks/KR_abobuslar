namespace TrafficLightsController;

public static class CrossroadController
{
    public static void ManageCrossroad(ICrossroad crossroad)
    {
        try
        {
            crossroad.ChangeAllowedDirection();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Возникла проблема: {ex.Message}");
        }
    }
}