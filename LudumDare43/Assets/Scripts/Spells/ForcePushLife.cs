using System.Collections;
using UnityEngine;

public class ForcePushLife : MonoBehaviour
{

	public float lifeSpan = 5;

	public int damage = 100;

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
			// Deal Damage
			//other.GetComponent<EnemyHealth>().TakeDamage(damage, new Vector3(0f, 0f, 0f));
			//Vector3 force = new Vector3(1f, 1f, 1f)
			//other.GetComponent<Rigidbody>().AddForce();
			StartCoroutine(DealDamageAfterWait(other.GetComponent<EnemyHealth>()));

		}
	}

	IEnumerator DealDamageAfterWait(EnemyHealth enemy)
	{
		yield return new WaitForSeconds(2f);
		enemy.TakeDamage(damage, new Vector3 (0f, 0f, 0f));
	}
	void SelfDestruct()
	{
		Destroy(gameObject);
	}
}
