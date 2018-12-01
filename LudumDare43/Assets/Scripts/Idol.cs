using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idol : MonoBehaviour {

    bool showLabel = false;
	// Use this for initialization
	void Start () {
		
	}

    private void OnGUI()
    {
        if (showLabel)
        {
            GUI.Label(new Rect(Screen.width-200, 50, 400, 100), "Press X to Pay Tribute");
        }
    }
    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            showLabel = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            showLabel = false;
        }
    }
}
