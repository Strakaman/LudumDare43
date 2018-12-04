using System.Collections;
using UnityEngine;

public class SpellBook : MonoBehaviour
{
    public ISpell[] mySpells  = new ISpell[3];
    private bool[] onCooldown = new bool[4];
    public SpellHUDCircleThingy[] spellHUDIcons = new SpellHUDCircleThingy[4];
    private bool cannotCast = false;

    public void Start()
    {

        for (int i = 0; i < 4; ++i)
        {
            onCooldown[i] = false;
        }
    }

    private void OnGUI()
    {
        if (cannotCast)
        {
            GUI.Label(new Rect((Screen.width/2)-200, 50, 400, 100), "CANNOT CAST SPELL - ON COOLDOWN");
        }

    }

    private void Update()
    {
        int currentSpell;
        // Check if spell was cast, else do nothing with currentSpell
        if (Input.GetButtonDown("Fire1"))
        {
            currentSpell = 0;
        }
        
        else if (Input.GetButtonDown("Fire2"))
        {
            currentSpell = 1;
        }
      
        else if (Input.GetButtonDown("Fire3"))
        {
            currentSpell = 2;
        }
        /*
        else if (Input.GetButtonDown("Spell_4"))
        {
            currentSpell = 3;
        }
        else if (Input.GetButtonDown("Spell_5"))
        {
            currentSpell = 4;
        }
        */
        else
        {
            return;
        }

        // Cast spell if not on cooldown
        if (onCooldown[currentSpell])
        {
            cannotCast = true;
            Invoke("ResetCannotCast", 1);
        }
        else
        {
            mySpells[currentSpell].Execute();
            onCooldown[currentSpell] = true;
            spellHUDIcons[currentSpell].StartGUICooldown(mySpells[currentSpell].cooldown);
            StartCoroutine(ResetSpell(currentSpell));
            // UPDATE THE HUD TO SHOW SPELL ON COOLDOWN
        }
        
        return;
    }

    private IEnumerator ResetSpell(int spellIdx)
    {
        yield return new WaitForSeconds(mySpells[spellIdx].cooldown);

        onCooldown[spellIdx] = false;
    }

    private void ResetCannotCast()
    {
        cannotCast = false;
    }
}
