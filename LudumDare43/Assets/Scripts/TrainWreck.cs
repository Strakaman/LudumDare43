using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainWreck : MonoBehaviour {

    public int Damage = 100;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHealth>().TakeDamage(Damage, new Vector3(0f, 0f, 0f));
        }
    }
}
