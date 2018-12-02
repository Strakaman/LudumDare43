using UnityEngine;

public class MakeItTrain : ISpell
{
    public int damage = 100;

    public GameObject TrainDrops;

    void Start()
    {
        cooldown = 10;
    }

    public override void Execute()
    {
        Quaternion spawnRotation = transform.rotation;
        Vector3 spawnPosition = transform.position + spawnRotation * (new Vector3(0f, -10f, -25f));

        GameObject createProjectile = Instantiate(TrainDrops, spawnPosition, spawnRotation);

        createProjectile.GetComponent<Rigidbody>().velocity = spawnRotation * (new Vector3(0f, 0f, 0f));
    }

}