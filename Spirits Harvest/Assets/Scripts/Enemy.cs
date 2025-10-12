using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    public Transform startPoint;

    Transform targetPoint;
    Transform currentPoint;

    void Start()
    {
        currentPoint = startPoint;
        targetPoint = currentPoint.transform;
    }

    void Update()
    {
        if (targetPoint == null)
            return;

        Vector3 dir = targetPoint.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, targetPoint.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        Waypoint waypoint = currentPoint.GetComponent<Waypoint>();
        int rand = UnityEngine.Random.Range(0, waypoint.nextWaypoints.Length);

        if (waypoint.nextWaypoints != null && waypoint.nextWaypoints.Length > 0)
        {
            targetPoint = waypoint.nextWaypoints[rand];
        }

        else if(waypoint.nextWaypoints == null || waypoint.nextWaypoints.Length == 0)
        {    
            this.gameObject.transform.position = startPoint.position;
            currentPoint = startPoint;
            targetPoint = currentPoint.transform;
            return;
        }

        currentPoint = waypoint.nextWaypoints[rand].transform;
        targetPoint = currentPoint;
    }
}
