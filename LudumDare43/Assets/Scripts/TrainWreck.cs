using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainWreck : MonoBehaviour {

    public int Damage = 100;
    private void OnTriggerEnter(Collider other)
    {
        CheckForDamage(other);
    }

    private void OnCollisionEnter(Collision collision)
    {
         CheckForDamage(collision.collider);
    }

    void CheckForDamage(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHealth>().TakeDamage(Damage, other.transform.position);
        }
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().TakeDamage(Damage);
        }
    }
}
