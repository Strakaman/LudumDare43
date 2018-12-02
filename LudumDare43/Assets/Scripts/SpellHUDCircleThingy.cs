using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellHUDCircleThingy : MonoBehaviour {

    public Image spellIcon;
    public Text cooldownLabel;

    int coolCurrTime;

    public void StartGUICooldown(int cooldownTime)
    {
        coolCurrTime = 0;
        StartCoroutine(CoolDownGUILoop(cooldownTime));
    }

    IEnumerator CoolDownGUILoop(int coolDownTime)
    {
        cooldownLabel.gameObject.SetActive( true);
        spellIcon.color = new Color(25, 25, 25);
        while (coolCurrTime < coolDownTime)
        {
            cooldownLabel.text = (coolDownTime- coolCurrTime).ToString();
            coolCurrTime++;
            yield return new WaitForSeconds(1f);
        }
        cooldownLabel.gameObject.SetActive(false);
        spellIcon.color = new Color(255, 0, 0);
        yield return null;
    }
}
