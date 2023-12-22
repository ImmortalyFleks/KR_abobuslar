using TrafficLightsController.Participants;

namespace TrafficLightsController.TrafficLights;

public class VehicleLight : TrafficLight
{
    public List<Transport> Transports { get; private set; }

    public VehicleLight(List<Transport> transports)
    {
        Transports = transports;
    }

    public override void ChangeLight()
    {
        if (IsGreen)
        {
            foreach (var p in Transports)
                p.Proceed();
        }
        else
        {
            RemoveCrossedTransports();
        }
        
        IsGreen = !IsGreen;
    }

    public void AddNewTransport(List<Transport> transports) => 
        Transports.AddRange(transports);

    private void RemoveCrossedTransports()
    {
        var resultList = new List<Transport>();
        foreach (var t in Transports)
        {
            if (!t.IsCrossed) 
                resultList.Add(t);
        }
        Transports = resultList;
    }
}