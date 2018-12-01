using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomWalk : MonoBehaviour {
    public Vector3 goal;
    public float moveCountdown = 5f;
    public Transform stayAround;
    public float moveRadius = 30f;
    NavMeshAgent agent;
    float timer;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        timer = moveCountdown;
    }
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            goal.x = Random.value * moveRadius;
            goal.y = Random.value * moveRadius;
            goal.z = Random.value * moveRadius;
            goal += stayAround.position;
            NavMeshHit hit;
            NavMesh.Raycast(transform.position, goal, out hit, NavMesh.AllAreas);
            agent.destination = hit.position;
            timer = moveCountdown;
        }
    }
}
