using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;

    Transform targetPoint;
    int waypointIndex;

    void Start()
    {
        targetPoint = Waypoints.points[0];
    }

    void Update()
    {
        Vector3 dir = targetPoint.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, targetPoint.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        waypointIndex = waypointIndex + 1;
        targetPoint = Waypoints.points[waypointIndex];
    }
}
