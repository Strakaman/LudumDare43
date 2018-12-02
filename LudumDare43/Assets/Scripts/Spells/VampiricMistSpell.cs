using UnityEngine;

public class VampiricMistSpell : ISpell
{
	public float projectileSpeed = 5;

	public GameObject BloodProjectile;

	void Start()
	{
		cooldown = 5;
	}

	public override void Execute()
	{
		Quaternion spawnRotation = transform.rotation;
		Vector3 spawnPosition = transform.position + spawnRotation * (new Vector3(0f, 1.5f, -1f));
		
		GameObject createProjectile = Instantiate(BloodProjectile, spawnPosition, spawnRotation);

		createProjectile.GetComponent<Rigidbody>().velocity = spawnRotation	* (new Vector3(0f, 0f, -projectileSpeed));

	}

}
