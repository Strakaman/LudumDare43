using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainSchedule : MonoBehaviour {

    public HazardTrain the_train;
	// Use this for initialization
	void Start () {
        StartCoroutine(TrainIsOnTime());
	}

    public float trainCoolDownTime=5f;

    IEnumerator TrainIsOnTime()
    {
        while (!GameController.instance.GameOver)
        {
            yield return new WaitForSeconds(trainCoolDownTime);
            the_train.StartTrain();
        }
    }
}
