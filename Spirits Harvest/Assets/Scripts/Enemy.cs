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

    Animator enemyAnimator;

    void Start()
    {
        startPoint = GameObject.FindGameObjectWithTag("EnemyStartPoint").transform;
        currentPoint = startPoint;
        targetPoint = currentPoint.transform;

        enemyAnimator = GetComponent<Animator>();

        int rand = UnityEngine.Random.Range(0, 7);
        enemyAnimator.SetInteger("AnimIndex", rand);
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
            Destroy(this.gameObject);
            return;
        }

        currentPoint = waypoint.nextWaypoints[rand].transform;
        targetPoint = currentPoint;
    }
}
