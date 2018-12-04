// MoveTo.cs
using UnityEngine;
using System.Collections;

public class MoveToPlayer : MonoBehaviour
{
    public Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        Vector3 vecToPlayer = playerTransform.position - this.transform.position;
        //while (vecToPlayer.magnitude > 10f)
    }
}