using UnityEngine;

public class VampiricMistLife : MonoBehaviour
{

	public float lifeSpan = 5;

	public int damage = 10;

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
			other.GetComponent<EnemyHealth>().TakeDamage(damage, new Vector3(0f, 0f, 0f));
		}
	}

	void SelfDestruct()
	{
		Destroy(gameObject);
	}
}
