using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KeyCards : MonoBehaviour
{
    [SerializeField] InventoryHandler.AllItems itemType;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player")) 
        {
            InventoryHandler.Instance.AddItem(itemType);
            Destroy(gameObject);
        }
    }
}
