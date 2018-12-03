using UnityEngine;

public class Idol : MonoBehaviour
{
    public PlayerHealth playerHealth;   // Ref to player health class

    bool playerInRange = false;  // Player has entered sacrifice area (sphere collider)

    enum SACRIFICE_STATE
    {
        No_Attempt,
        Success,
        Fail
    };
    SACRIFICE_STATE sacrificeSufficient = SACRIFICE_STATE.No_Attempt;
	
    // Use this for initialization
	void Start()
    {

	}

    private void OnGUI()
    {
        if (playerInRange)
        {
            GUI.Label(new Rect(Screen.width-200, 50, 400, 100), "Press X to Pay Tribute");
            
            if (sacrificeSufficient != SACRIFICE_STATE.No_Attempt)
            {
                if (sacrificeSufficient == SACRIFICE_STATE.Success)
                {
                    GUI.Label(new Rect(Screen.width-260, 70, 400, 100), "Donation accepted. The gods are pleased...");
                }
                else
                {
                    GUI.Label(new Rect(Screen.width-200, 70, 400, 100), "Bloodbank funds insufficient");
                }

                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
		// Submit mapped to x key
        if (playerInRange && Input.GetButtonDown("Submit"))
        {
            // Sacrifice blood here
            if (playerHealth.currentBlood > 0)
            {
                int bloodToHealthRatio = 1;
                sacrificeSufficient = SACRIFICE_STATE.Success;
                int tribute = playerHealth.SacrificeBlood();
                    
                // Convert blood to health
                int reward = tribute/bloodToHealthRatio;

                // Heal player
                playerHealth.Heal(reward);
                GetComponent<SoundFxManager>().PlayRandom(GetComponent<AudioSource>());

            }
            else
            {
                sacrificeSufficient = SACRIFICE_STATE.Fail;
            }

            // Reset enum after time so message disappears
            Invoke("ResetSacrifice", 2f);
        }
	}

    private void ResetSacrifice()
    {
        sacrificeSufficient = SACRIFICE_STATE.No_Attempt;
    }

    // On Enter with Sphere Collider Trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            playerInRange = true;
        }
    }

    // On Exit from Sphere Collider Trigger
    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            playerInRange = false;
        }
    }
}
