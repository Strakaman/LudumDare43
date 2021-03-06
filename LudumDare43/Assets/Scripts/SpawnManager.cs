﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    //public PlayerHealth playerHealth;       // Reference to the player's heatlh.
    public GameObject[] enemyType;                // The enemy prefab to be spawned.
    public float spawnTime = 10f;            // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
    public int maxEnemies = 50;


    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn()
    {
        //// If the player has no health left...
        //if (playerHealth.currentHealth <= 0f)
        //{
        //    // ... exit the function.
        //    return;
        //}

        int spawnedEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (spawnedEnemies > maxEnemies)
        {
            return;
        }

        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        int enemyTypeIndex = Random.Range(0, enemyType.Length);
        Vector3 randomizedOffset = Random.insideUnitCircle;
        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(enemyType[enemyTypeIndex], spawnPoints[spawnPointIndex].position + randomizedOffset, spawnPoints[spawnPointIndex].rotation);
    }
}