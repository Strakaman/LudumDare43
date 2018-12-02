using UnityEngine;
using System.Collections;

public class BloodToPlayer : MonoBehaviour
{
    public int Pints = 0;
    public Transform playerTransform;
    public float speed = 1.0f;

    private Vector3 playerPosition;
    private Vector3 startPosition;
    private float journeyLength;
    private int steps;

    // Call this to set blood content on enemy death
    public void FillPints(int amount)
    {
        Pints = amount;
    }

    // Use this for initialization
    void Start()
    {
        startPosition = transform.position;
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        steps = 0;
    }

    void Update()
    {
        float distanceCovered = (steps * Time.deltaTime) * speed;
        float fraction = distanceCovered/journeyLength;
        transform.position = Vector3.Lerp(startPosition, playerPosition, fraction);
        ++steps;
    }
    
    void FixedUpdate()
    {
        playerPosition = playerTransform.position;
        journeyLength = Vector3.Distance((playerPosition - startPosition), startPosition);
    }
}
