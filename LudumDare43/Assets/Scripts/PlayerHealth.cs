using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
	public int startHealth = 100;                      // Starting player health
	public int currentHealth;                          // Current player health
	public Slider healthSlider;                        // Ref to UI health bar.
	public Image damageImage;                          // Ref to image that flashes on player damage
	public float flashspeed = 5f;                      // Speed that image damage image fades at
	public Color flashColor = new Color(1f, 0f, 0.1f); // Color of damage image to flash
	public AudioClip deathClip;

	Animator anim;                                     // Ref to Animator component
	AudioSource playerAudio;                            // Ref to AudioSource component
	//PlayerMovement playerMovement;                     // NEED REF TO PLAYER'S MOVEMENT SCRIPT??
	//SpellBook spellBook;     NEED REFERENCE TO PLAYER SPELLBOOK (damage dealing) SCRIPT?????
	bool isDead;                                       // Whether player is dead
	bool damaged;                                      // When the player gets damaged

	// Use this for initialization
	void Awake()
	{
		
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}
}
