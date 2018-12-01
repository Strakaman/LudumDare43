using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idol : MonoBehaviour
{

    bool playerInRange = false;  // Player has entered sacrifice area (sphere collider)
	
    // Use this for initialization
	void Start()
    {
		
	}

    private void OnGUI()
    {
        if (playerInRange)
        {
            GUI.Label(new Rect(Screen.width-200, 50, 400, 100), "Press X to Pay Tribute");
        }
    }
    // Update is called once per frame
    void Update()
    {
		
	}

    // On Enter with Sphere Collider Trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            playerInRange = true;
        }
    }

    // On Exit from Sphere Collider Trigger
    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            playerInRange = false;
        }
    }
}
