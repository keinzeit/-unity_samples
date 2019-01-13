using System;

public class SpotManager : MonoBehaviour
{
    public Spot[] spots;

    public NavMeshAgent agent;

    public void FindSpotCoordinates(string name)
    {
        Spot s = Array.Find(spots, spot => spot.name == name);

        if (s == null)
        {
            Debug.LogWarning("Spot <" + name + "> not found!");
            return;
        }

        agent.SetDestination(s.coordinates);
    }


}
