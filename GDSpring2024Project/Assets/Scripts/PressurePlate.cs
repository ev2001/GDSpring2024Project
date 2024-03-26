using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressurePlate : MonoBehaviour
{
    public int sceneBuildIndex;
    [SerializeField] List<InventoryHandler.AllItems> requiredItems;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Pressure plate was triggered.");
        //GetComponent<SpriteRenderer>().color = Color.blue;
        //other.GetComponent<SpriteRenderer>().color = Color.red;
        if(RequiredItemsCollected()) 
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
    public bool RequiredItemsCollected() 
    {
        int collectedCount = 0;

        foreach (InventoryHandler.AllItems requiredItem in requiredItems)
        {
            if (InventoryHandler.Instance.inventoryItems.Contains(requiredItem))
            {
                collectedCount++;
            }
        }

        return collectedCount >= 3;
    }
}
