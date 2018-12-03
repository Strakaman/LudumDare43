using UnityEngine;

public class TrainLife : MonoBehaviour
{

    public float lifeSpan = 10;

    public int Damage = 100;

    // Use this for initialization
    void Start()
    {
        Invoke("SelfDestruct", lifeSpan);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
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

    void SelfDestruct()
    {
        Destroy(gameObject);
    }
}