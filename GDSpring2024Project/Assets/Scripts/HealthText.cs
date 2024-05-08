using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;
    //[SerializeField] CreatureSO creatureSO;
    [SerializeField] private Creature PlayerCharacter;

    public void Update()
    {
        if(PlayerCharacter != null) {
            healthText.text = "LIVES " + PlayerCharacter.health.ToString();
        }
        else{
            healthText.text = "LIVES ";
        }
        //if (PlayerCharacter != null && PlayerCharacter.creatureSO != null) 
        //{
            //healthText.text = "LIVES " + PlayerCharacter.creatureSO.health.ToString();   
        //}
        //else
        //{
            //healthText.text = "LIVES ";
        //}
    }
}
