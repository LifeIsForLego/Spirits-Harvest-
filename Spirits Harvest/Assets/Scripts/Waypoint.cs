using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Transform[] nextWaypoints;

    private void Awake()
    {
        nextWaypoints = new Transform[transform.childCount];
        for (int i = 0; i < nextWaypoints.Length; i++)
        {
            nextWaypoints[i] = transform.GetChild(i);
        }
    }
}
