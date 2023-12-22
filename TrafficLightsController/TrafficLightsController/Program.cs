using TrafficLightsController.Crossroads;
using TrafficLightsController.Participants;
using TrafficLightsController.TrafficLights;

namespace TrafficLightsController;

public class Program
{
    public static void Main()
    {
        var vps = new List<Pedestrian> {new("Victor"), new("Vally")};
        var vts = new List<Transport> {new("V111VV"), new("V222VV")};
        
        var hps = new List<Pedestrian> {new("Herald"), new("Hornet")};
        var hts = new List<Transport> {new("H111HH"), new("H222HH")};

        var horizontalLights = new List<TrafficLight>();
        var verticalLights = new List<TrafficLight>();
        
        horizontalLights.Add(new PedestrianLight(hps));
        horizontalLights.Add(new VehicleLight(hts));
        verticalLights.Add(new PedestrianLight(vps));
        verticalLights.Add(new VehicleLight(vts));
        
        var crossroad = new Crossroad(horizontalLights, verticalLights);
        
        CrossroadController.ManageCrossroad(crossroad);
        CrossroadController.ManageCrossroad(crossroad);
    }
}