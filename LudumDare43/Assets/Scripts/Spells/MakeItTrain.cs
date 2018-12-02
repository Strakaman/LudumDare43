﻿using UnityEngine;

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
        Vector3 spawnPosition = transform.position + spawnRotation * (new Vector3(50f, -10f, 0f));

        GameObject createProjectile = Instantiate(TrainDrops, spawnPosition, spawnRotation);

        createProjectile.GetComponent<Rigidbody>().velocity = spawnRotation * (new Vector3(0f, -1f, 0f));
    }

}