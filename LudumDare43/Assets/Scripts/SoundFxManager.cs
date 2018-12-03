using UnityEngine;

public class SoundFxManager : MonoBehaviour
{

    public AudioClip[] audioClips;

	// Use this for initialization
	void Start()
    {
		
	}
	
	// Update is called once per frame
	void Update()
    {
		
	}

    public void PlayRandom(AudioSource audioSource)
    {
        int num = Mathf.RoundToInt(Random.Range(0f, (audioClips.Length - 1)));
        Debug.Log("Play Train " + num.ToString());
        audioSource.clip = audioClips[num];
        audioSource.Play();
    }
}
