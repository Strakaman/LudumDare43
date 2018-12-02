using UnityEngine;

public class getAxedSpell : ISpell
{
    public int damage = 10;

    public GameObject AxeProjectile;

    void Start()
    {
        cooldown = 2;
    }

    public override void Execute()
    {
        Quaternion spawnRotation = transform.rotation;
        Vector3 spawnPosition = transform.position + spawnRotation * (new Vector3(0f, 0f, 1f));

        GameObject createProjectile = Instantiate(AxeProjectile, spawnPosition, spawnRotation);

        //createProjectile.GetComponent<Rigidbody>().velocity = spawnRotation * (new Vector3(-projectileSpeed, 0f, 3f));

    }

}