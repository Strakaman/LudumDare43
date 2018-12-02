using UnityEngine;

public class ForcePushSpell : ISpell
{
	public float projectileSpeed = 20;

	public GameObject ForceProjectile;

	void Start()
	{
		cooldown = 1;
	}

	public override void Execute()
	{
		Quaternion spawnRotation = transform.rotation;
		Vector3 spawnPosition = transform.position + spawnRotation * (new Vector3(0f, 1.5f, -3f));
		
		GameObject createProjectile = Instantiate(ForceProjectile, spawnPosition, spawnRotation);

		createProjectile.GetComponent<Rigidbody>().velocity = spawnRotation	* (new Vector3(0f, 0f, -projectileSpeed));

	}

}
