using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class BotPatrolBehaviour : MonoBehaviour {

	private NavMeshAgent agent;
	private Transform[] waypoints;
	private int currentWaypointInt;


	void Start()
	{	
		agent = GetComponent<NavMeshAgent>();
		GetWaypoints();
	}

	void GetWaypoints()
	{
		waypoints = GameObject.Find("Waypoints").GetComponent<WaypointManager>().waypoints;
		currentWaypointInt = -1;
		SetNextWaypoint();
	}

	void Update()
	{
		if(agent.remainingDistance <= agent.stoppingDistance)
		{
			SetNextWaypoint();
		}
	}

	void SetNextWaypoint()
	{
		currentWaypointInt += 1;
		if(currentWaypointInt >= waypoints.Length)
		{
			currentWaypointInt = 0;
		}

		agent.SetDestination(waypoints[currentWaypointInt].position);
	}

}
