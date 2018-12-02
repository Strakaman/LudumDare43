using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainWreck : MonoBehaviour {

    public int Damage = 10000;

    private void OnCollisionEnter(Collision collision)
    {
        if ( collision.gameObject.CompareTag("Enemy")) 
        {
            Debug.Log("Train hit " + collision.gameObject.name);
        }
    }
}
