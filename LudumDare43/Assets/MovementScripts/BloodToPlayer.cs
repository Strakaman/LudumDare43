using UnityEngine;
using System.Collections;

public class BloodToPlayer : MonoBehaviour
{
    public int Pints = 0;
    public Transform playerTransform;

    private Vector3 targetLocation;
    private Vector3 distanceToGo;

    // Call this to set blood content on enemy death
    public void FillPints(int amount)
    {
        Pints = amount;
    }

    // Use this for initialization
    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        
    }
    
    void FixedUpdate()
    {
        targetLocation = playerTransform.position;
        distanceToGo = targetLocation - transform.position;
    }
}
