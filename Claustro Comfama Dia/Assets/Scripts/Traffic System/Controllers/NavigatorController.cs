using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigatorController : MonoBehaviour
{
    public Waypoint currentWaypoint;
    private CharacterNavigationController controller;
    private int direction;
    void Start()
    {
        direction = Mathf.RoundToInt(Random.Range(0f,1f));
        controller = GetComponent<CharacterNavigationController>();
        controller.SetDestination(currentWaypoint.GetPosition());
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.reachedDestination) {
            if (direction == 0)
            {
                currentWaypoint = currentWaypoint.nextWaypoint;
            }
            else if (direction == 1){
                currentWaypoint = currentWaypoint.previousWaypoint;
            }

            controller.SetDestination(currentWaypoint.GetPosition());
        }
    }
}
