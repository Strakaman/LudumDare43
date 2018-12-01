using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodBall : MonoBehaviour {


   public void ShootProjectile(Vector3 velocity)
    {
        GetComponent<Rigidbody>().velocity = velocity;
    }
}
