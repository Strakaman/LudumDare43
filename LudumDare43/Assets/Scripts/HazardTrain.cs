using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardTrain : MonoBehaviour {
    public GameObject endPosition;
    public GameObject trainVisualHolder;
    Vector3 startpos;
    // Use this for 
    float frac;
	void Start () {
        startpos = transform.position;
	}
	
    public void StartTrain()
    {
        trainVisualHolder.SetActive(true);
        transform.position = startpos;
        frac = 0;
    }

	// Update is called once per frame
	void Update () {
        if (frac > 1) {
            trainVisualHolder.SetActive(false);
            return; }
        transform.position = Vector3.Lerp(startpos, endPosition.transform.position, frac);
        frac += .005f;
	}
}
