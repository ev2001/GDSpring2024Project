using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StaminaText : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI staminaText;
   //[SerializeField] CreatureSO creatureSO;
   [SerializeField] private Creature PlayerCharacter;

    // Update is called once per frame
    public void Update()
    {
        if (PlayerCharacter != null && PlayerCharacter.creatureSO != null)
        {
            staminaText.text = "STAMINA " + PlayerCharacter.creatureSO.stamina.ToString();
        }
        else
        {
            staminaText.text = "STAMINA ";
        }
    }
}
