using UnityEngine;
using UnityEngine.UI;
using Invector.CharacterController;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	public int startingHealth = 100;                    // Starting player health
	public int currentHealth;                           // Current player health
	//public Slider healthSlider;                       // Ref to UI health bar.
	public int currentBlood;                            // Blood that player has
	public Image damageImage;                           // Ref to image that flashes on player damage
	public float flashspeed = 5f;                       // Speed that image damage image fades at
	public Color damageFlash = new Color(1f, 0f, 0.1f); // Color of damage image to flash
	public Color healFlash = new Color(0f, 1f, 0.1f);   // Color of heal image to flash
	public int flashThreshold = 10;                     // Damage threshold for screen flash
	public AudioClip deathClip;                         // Sound played on death

	Animator anim;                                      // Ref to Animator component
	AudioSource playerAudio;                            // Ref to AudioSource component - IS THIS WHERE WE ADD DAMAGE SOUND?
	vThirdPersonInput playerMovement;                   // Ref to player movment class
	SpellBook spellBook;                                // Ref to spellbook class
	bool isDead;                                        // Whether player is dead
	bool damaged;                                       // When the player gets damaged
	bool healed;                                       // When the player gets healed

    public int dyingDamagePerInterval= 1;
    public float dyingInterval = .5f;

	// Use this for initialization
	void Awake()
	{
		// Set up references
		anim = GetComponent<Animator>();
		playerAudio = GetComponent<AudioSource>();
		playerMovement = GetComponent<vThirdPersonInput>();
		spellBook = GetComponent<SpellBook>();

		// Set the initial health and blood
		currentHealth = startingHealth;
		currentBlood = 0;
		Debug.Log("Starting Health: " + startingHealth.ToString());
		Debug.Log("Starting Blood: " + currentBlood.ToString());

		isDead = false;
		damaged = false;
		healed = false;
		damageImage.color = Color.clear;
	}

    private void Start()
    {
        StartCoroutine(SlowlyDamage());
    }
    // Update is called once per frame
    void Update()
	{
		// If damaged, flash the damage color on screen
		// Else, fade damage color away
		if (damaged)
		{
			damageImage.color = damageFlash;
		}
		else if (healed)
		{
			damageImage.color = healFlash;
		}
		else
		{
			damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashspeed * Time.deltaTime);
		}

		// Reset damaged and healed every frame
		damaged = false;
		healed = false;


	}

    IEnumerator SlowlyDamage()
    {
        //player is slowly dying
        yield return new WaitForSeconds(2);
        while (!GameController.instance.GameOver)
        {
            yield return new WaitForSeconds(dyingInterval);
            currentHealth -= dyingDamagePerInterval;
            CheckIfDead();
        }
    }
	// Hurt the player - call from other classes
	public void TakeDamage(int amount)
    {
        // Only run on live players
        if (!isDead)
        {
            // Player always ticks damage with time
            // Only set flag on big hits so we don't always flash
            if (amount >= flashThreshold)
            {
                damaged = true;
            }

            // Damage player
            currentHealth -= amount;

            // Set Health Bar
            // This assumes health bar is int based and not fraction based
            //healthSlider.value = currentHealth;
            Debug.Log("Health: " + currentHealth.ToString());

            // Play hurt sound
            // playerAudio.Play();
        }

        CheckIfDead();
    }

    private void CheckIfDead()
    {
        // Check if player is dead
        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    // Heal the player - call from other classes
    public void Heal(int amount)
	{
		healed = true;

		currentHealth += amount;
		if (currentHealth > startingHealth)
		{
			currentHealth = startingHealth;
		}

		// Set Health Bar
		// This assumes health bar is int based and not fraction based
		//healthSlider.value = currentHealth;
		Debug.Log("Health: " + currentHealth.ToString());

		// Play heal sound

	}

	public void AddBlood(int amount)
	{
		currentBlood += amount;
		

		// Update Blood HUD
		Debug.Log("Blood: " + currentBlood.ToString());
	}

	// Sacrifice method empties as much blood
	// Add logic to prevent over healing/save blood?
	public int SacrificeBlood()
	{
		int blood = currentBlood;
		currentBlood = 0;

		// Update Blood HUD
		Debug.Log("Blood: " + currentBlood.ToString());

		return blood;
	}

	// Kill the player
	void Death()
	{
		// Set death flag
		isDead = true;
		Debug.Log("YOU DIED");

		// Disable effects from spellbook
		spellBook.enabled = false;


		// Call death animation, audio, etc
		//anim.SetTrigger("Die");
		//playerAudio.clip = deathClip;
		//playerAudio.Play();

		// Disable player controlls, movement, etc
		playerMovement.enabled = false;
	}
}
