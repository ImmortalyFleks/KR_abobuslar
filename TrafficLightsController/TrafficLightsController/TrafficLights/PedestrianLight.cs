using TrafficLightsController.Participants;

namespace TrafficLightsController.TrafficLights;

public class PedestrianLight : TrafficLight
{
    public List<Pedestrian> Pedestrians { get; private set; }

    public PedestrianLight(List<Pedestrian> pedestrians)
    {
        TrafficLightId = Guid.NewGuid();
        Pedestrians = pedestrians;
    }

    public override void ChangeLight()
    {
        if (IsGreen)
        {
            foreach (var p in Pedestrians)
                p.Proceed();
        }
        else
        {
            RemoveCrossedPedestrians();
        }
        
        IsGreen = !IsGreen;
    }

    public void AddNewPedestrians(List<Pedestrian> pedestrians) => 
        Pedestrians.AddRange(pedestrians);

    public void RemoveCrossedPedestrians()
    {
        var resultList = new List<Pedestrian>();
        foreach (var t in Pedestrians)
        {
            if (!t.IsCrossed) 
                resultList.Add(t);
        }
        Pedestrians = resultList;
    }
}