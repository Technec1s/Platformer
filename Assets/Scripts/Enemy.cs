using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform[] waypoints;
    public float moveSpeed = 5f;
    public bool reversePatrol = false;

    private int currentWaypointIndex;
    private Transform targetWaypoint;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        currentWaypointIndex = 0;
        targetWaypoint = waypoints[currentWaypointIndex];
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, moveSpeed * Time.deltaTime);

        if (transform.position == targetWaypoint.position)
        {
            if (reversePatrol)
            {
                currentWaypointIndex--;
                if (currentWaypointIndex < 0)
                    currentWaypointIndex = waypoints.Length - 1;
            }
            else
            {
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Length)
                    currentWaypointIndex = 0;
            }

            targetWaypoint = waypoints[currentWaypointIndex];
        }

        Vector3 moveDirection = targetWaypoint.position - transform.position;

        if (moveDirection.x > 0)
            spriteRenderer.flipX = true;
        else if (moveDirection.x < 0)
            spriteRenderer.flipX = false;
    }
}