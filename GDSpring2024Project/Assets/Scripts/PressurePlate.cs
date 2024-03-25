using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressurePlate : MonoBehaviour
{
    public int sceneBuildIndex;
    [SerializeField] InventoryHandler.AllItems requiredItems;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Pressure plate was triggered.");
        //GetComponent<SpriteRenderer>().color = Color.blue;
        //other.GetComponent<SpriteRenderer>().color = Color.red;
        if(RequiredItems(requiredItems)) 
        {
            if (other.tag == "Player")
            {
                Debug.Log("Switing Scene to " + sceneBuildIndex);
                SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
            }
        }
    }
    //void OnTriggerExit2D(Collider2D other)
    //{
        //GetComponent<SpriteRenderer>().color = Color.white;
    //}
    public bool RequiredItems(InventoryHandler.AllItems requiredItems) 
    {
        if (InventoryHandler.Instance.inventoryItems.Contains(requiredItems))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
