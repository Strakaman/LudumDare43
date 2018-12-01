using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignRandomWalkToIdol : MonoBehaviour {
    RandomWalk randomWalk;

	// Use this for initialization
	void Start () {
        randomWalk = GetComponent<RandomWalk>();
        Transform idolLocation = GameObject.FindWithTag("Idol").GetComponent<Transform>();
        randomWalk.stayAround = idolLocation;
	}
}
