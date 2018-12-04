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
        transform.eulerAngles = new Vector3(0, 90, 0);
        frac = 0;
    }

    private void FixedUpdate()
    {
        if (frac > 1)
        {
            trainVisualHolder.SetActive(false);
            return;
        }
        transform.position = Vector3.Lerp(startpos, endPosition.transform.position, frac);
        frac += .005f;
    }

}


