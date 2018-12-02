using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodBall : MonoBehaviour {


   public void ShootProjectile(Vector3 velocity)
    {
        GetComponent<Rigidbody>().velocity = velocity;
    }
}

// CODE DELETED FROM SPELLBOOK.CS IN CASE WE WANT TO SAVE IT

/*
public GameObject BloodBallPrefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1"))
        {
            BloodBall();
        }
	}

    void BloodBall()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0, 1.5f, 0);
        GameObject createdObj =  Instantiate(BloodBallPrefab, spawnPosition,Quaternion.identity);
        createdObj.GetComponent<BloodBall>().ShootProjectile(new Vector3(5, 0, 5));
    }
*/