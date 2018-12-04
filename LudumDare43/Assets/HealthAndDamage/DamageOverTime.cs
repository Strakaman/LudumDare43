using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOverTime : MonoBehaviour {
    public struct DotStruct
    {
        public float damagePerSecond;
        public float secondsRemaining;
    }

    public List<DotStruct> currentDots;
    public float updatesPerSecond = 10;

    EnemyHealth health;
    float secondCounter;

    // Use this for initialization
    void Start () {
        currentDots = new List<DotStruct>();
        health = GetComponent<EnemyHealth>();
        secondCounter = 1 / updatesPerSecond;
    }
    
    // Update is called once per frame
    void Update () {
        secondCounter -= Time.deltaTime;
        if (secondCounter < 0)
        {
            foreach (var dot in currentDots)
            {
                int damagePerQuarter = (int)(dot.damagePerSecond / updatesPerSecond);
                Debug.Log("Take dmg " + damagePerQuarter);
                health.TakeDamage(damagePerQuarter, Vector3.zero);
                UpdateDotTime(dot);
                if (dot.secondsRemaining < 0)
                {
                    currentDots.Remove(dot);
                }
            }
            secondCounter = 1 / updatesPerSecond;
        }
    }

    void UpdateDotTime(DotStruct dot)
    {
        dot.secondsRemaining -= 1 / updatesPerSecond;
    }

    public void TakeDotDamage(float damagePerSecond, float lengthInSeconds)
    {
        DotStruct dot;
        dot.damagePerSecond = damagePerSecond;
        dot.secondsRemaining = lengthInSeconds;
        currentDots.Add(dot);
    }
}
