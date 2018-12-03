using UnityEngine;

public class SoundFxManager : MonoBehaviour
{

    public AudioClip[] audioClips;
    public AudioSource audioSource;

	// Use this for initialization
	void Start()
    {
		
	}
	
	// Update is called once per frame
	void Update()
    {
		
	}

    public void PlayRandom()
    {
        audioSource.clip = audioClips[Mathf.RoundToInt(Random.Range(0f, (audioClips.Length - 1)))];
        audioSource.Play();
    }
}
